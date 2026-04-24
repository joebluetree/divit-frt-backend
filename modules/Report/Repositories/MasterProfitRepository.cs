using Database;
using Database.Lib;
using Common.DTO.Masters;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.Masters;
using Database.Models.BaseTables;
using Common.Lib;

using Common.DTO.SeaExport;
using Database.Models.Cargo;
using SeaExport.Interfaces;
using System.Threading.Tasks.Dataflow;
using System.Numerics;
using SeaExport.Printing;
using Report.Interfaces;
using Common.DTO.Report;
using Report.Printing;

//Name : Sourav V
//Created Date : 09/02/2026
//Remark : this file defines functions getList and getRecords of operations for Shipment Master Profit report/summary


namespace Report.Repositories
{
    public class MasterProfitRepository : IMasterProfitRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public MasterProfitRepository(AppDbContext _context, IAuditLog _auditLog)
        {
            this.context = _context;
            this.auditLog = _auditLog;
        }

        public async Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();

                Page _page = new Page();

                var action = data["action"].ToString();
                if (action == null)
                    action = "search";
                bool isPrint = false;
                var title = data["title"].ToString();
                var user_name = data["global_user_name"].ToString();

                var mbl_from_date = "";
                var mbl_to_date = "";
                var mbl_format = "";
                var mbl_mode = "";
                var mbl_report_type = "";
                var mbl_salesman_name = "";
                var mbl_agent_name = "";
                var mbl_parent_name = "";
                var mbl_customer_name = "";
                var mbl_profit_criteria = "";
                decimal mbl_profit_val = 0;
                var mbl_profit_met = "";
                var mbl_loss_approved = "";


                var company_id = 0;
                var branch_id = 0;

                DateOnly? from_date = null;
                DateOnly? to_date = null;

                if (data.ContainsKey("mbl_from_date"))
                    mbl_from_date = data["mbl_from_date"].ToString();
                if (data.ContainsKey("mbl_to_date"))
                    mbl_to_date = data["mbl_to_date"].ToString();
                if (data.ContainsKey("mbl_format"))
                    mbl_format = data["mbl_format"].ToString();
                if (data.ContainsKey("mbl_mode"))
                    mbl_mode = data["mbl_mode"].ToString();
                if (data.ContainsKey("mbl_report_type"))
                    mbl_report_type = data["mbl_report_type"].ToString();
                if (data.ContainsKey("mbl_agent_name"))
                    mbl_agent_name = data["mbl_agent_name"].ToString();

                if (data.ContainsKey("mbl_salesman_name"))
                    mbl_salesman_name = data["mbl_salesman_name"].ToString();
                if (data.ContainsKey("mbl_parent_name"))
                    mbl_parent_name = data["mbl_parent_name"].ToString();
                if (data.ContainsKey("mbl_customer_name"))
                    mbl_customer_name = data["mbl_customer_name"].ToString();

                if (data.ContainsKey("mbl_profit_criteria"))
                    mbl_profit_criteria = data["mbl_profit_criteria"].ToString();
                if (data.ContainsKey("mbl_profit_val"))
                    mbl_profit_val = decimal.Parse(data["mbl_profit_val"].ToString()!);
                if (data.ContainsKey("mbl_profit_met"))
                    mbl_profit_met = data["mbl_profit_met"].ToString();
                if (data.ContainsKey("mbl_loss_approved"))
                    mbl_loss_approved = data["mbl_loss_approved"].ToString();

                company_id = Lib.GetValidIntValue(data!, "rec_company_id", "Company Id Not Found");
                branch_id = Lib.GetValidIntValue(data!, "rec_branch_id", "Branch Id Not Found");

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                if (action == "PRINT" || action == "EXCEL" || action == "PDF")
                {
                    isPrint = true;
                }
                var fileDataList = new List<filesm>();
                var searchInfo = new Dictionary<string, string>
                {
                    {"mbl_from_date",mbl_from_date!},
                    {"mbl_to_date",mbl_to_date!},
                    {"mbl_format", mbl_format!},
                    {"mbl_mode", mbl_mode!},
                    {"mbl_report_type", mbl_report_type!},
                    {"mbl_salesman_name", mbl_salesman_name!},
                    {"mbl_agent_name", mbl_agent_name!},
                    {"mbl_parent_name", mbl_parent_name!},
                    {"mbl_customer_name", mbl_customer_name!},
                    {"mbl_profit_criteria", mbl_profit_criteria!},
                    {"mbl_profit_val", mbl_profit_val.ToString()!},
                };

                IQueryable<cargo_masterm> query = context.cargo_masterm;

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);

                if (!Lib.IsBlank(mbl_from_date))
                {
                    from_date = Lib.ParseDateOnly(mbl_from_date!);
                    query = query.Where(w => w.mbl_ref_date >= from_date);
                }
                if (!Lib.IsBlank(mbl_to_date))
                {
                    to_date = Lib.ParseDateOnly(mbl_to_date!);
                    query = query.Where(w => w.mbl_ref_date <= to_date);
                }
                if (!Lib.IsBlank(mbl_salesman_name))
                {
                    query = query.Where(w => w.salesman!.param_name == mbl_salesman_name);
                }
                if (!Lib.IsBlank(mbl_agent_name))
                {
                    query = query.Where(w => w.agent!.cust_name == mbl_agent_name);
                }
                if (!Lib.IsBlank(mbl_parent_name))
                {
                    query = query.Where(w => w.agent!.customer!.cust_name == mbl_parent_name);
                }
                if (!Lib.IsBlank(mbl_customer_name))
                {
                    query = query.Where(w => w.customer!.cust_name == mbl_customer_name);
                }
                if (!Lib.IsBlank(mbl_mode))
                {
                    if (mbl_mode == "ALL")
                    {
                        var Types = new[] { "SEA IMPORT", "SEA EXPORT", "AIR IMPORT", "AIR EXPORT","OTHERS" };
                        query = query.Where(w => Types.Contains(w.mbl_mode));
                    }
                    else
                    {
                        query = query.Where(w => w.mbl_mode == mbl_mode);
                    }
                }
                if (mbl_report_type == "MASTER")
                {
                    if (!Lib.IsBlank(mbl_profit_criteria))
                    {
                        if (mbl_profit_criteria == "PROFIT =")
                            query = query.Where(w => w.mbl_revenue == mbl_profit_val);
                        if (mbl_profit_criteria == "PROFIT <")
                            query = query.Where(w => w.mbl_revenue < mbl_profit_val);
                        if (mbl_profit_criteria == "PROFIT >")
                            query = query.Where(w => w.mbl_revenue > mbl_profit_val);
                        if (mbl_profit_criteria == "PROFIT PER =")
                            query = query.Where(w => w.mbl_per == mbl_profit_val);
                        if (mbl_profit_criteria == "PROFIT PER <")
                            query = query.Where(w => w.mbl_revenue < mbl_profit_val);
                        if (mbl_profit_criteria == "PROFIT PER >")
                            query = query.Where(w => w.mbl_revenue > mbl_profit_val);
                    }
                    if (mbl_profit_met == "Y")
                    {
                        query = query.Where(w => w.mbl_profit_req == "N" || w.mbl_profit_req == null); // to hide list profit req met
                    }
                    if (mbl_loss_approved == "Y")
                    {
                        query = query.Where(w => w.mbl_loss_approved == "N" || w.mbl_loss_approved == null); // to hide list loss approved
                    }
                }
                var totals = query.Select(s => new
                {
                    mbl_house_tot = s.mbl_house_tot ?? 0,
                    mbl_inc_total = s.mbl_inc_total ?? 0,
                    mbl_exp_total = s.mbl_exp_total ?? 0,
                    mbl_profit = s.mbl_inc_total - s.mbl_exp_total ?? 0,
                    mbl_pcs = s.mbl_pcs ?? 0,
                    mbl_20 = s.mbl_20 ?? 0,
                    mbl_40 = s.mbl_40 ?? 0,
                    mbl_40hq = s.mbl_40hq ?? 0,
                    mbl_45 = s.mbl_45 ?? 0,
                    mbl_teu = s.mbl_teu ?? 0,
                    mbl_cbm = s.mbl_cbm ?? 0,
                    mbl_weight = s.mbl_weight ?? 0,
                });

                var totalExpense = totals.Sum(x => x.mbl_exp_total);
                var totalProfit = totals.Sum(x => x.mbl_profit);

                var totalRow = new rep_masterprofit_dto
                {
                    mbl_agent_name = action=="PRINT" ? "":"TOTAL",
                    mbl_refno = action=="PRINT" ? "GRAND TOTAL":"",
                    mbl_mode = action=="PRINT" ? "GRAND TOTAL":"TOTAL",
                    mbl_ref_count = totals.Count(),
                    mbl_house_tot = totals.Sum(x => x.mbl_house_tot),
                    mbl_inc_total = totals.Sum(x => x.mbl_inc_total),
                    mbl_exp_total = totalExpense,
                    mbl_revenue = totalProfit,
                    mbl_profit_per = !Lib.IsZero(totalExpense) ? Math.Round((totalProfit / totalExpense) * 100, 3) : 0, // profit %
                    mbl_pcs = totals.Sum(x => x.mbl_pcs),
                    mbl_20 = totals.Sum(x => x.mbl_20),
                    mbl_40 = totals.Sum(x => x.mbl_40),
                    mbl_40hq = totals.Sum(x => x.mbl_40hq),
                    mbl_45 = totals.Sum(x => x.mbl_45),
                    mbl_teu = totals.Sum(x => x.mbl_teu),
                    mbl_cbm = totals.Sum(x => x.mbl_cbm),
                    mbl_weight = totals.Sum(x => x.mbl_weight),
                };

                List<rep_masterprofit_dto> Records = new List<rep_masterprofit_dto>();

                if (mbl_report_type == "MASTER" && mbl_format != "PARTY")
                {
                    query = query.OrderBy(o => o.mbl_refno);

                    if (action == "SEARCH" || action == "PRINT" || action == "EXCEL" || action == "PDF")
                    {
                        _page.rows = query.Count(); // add 1 for total count
                        _page.pages = Lib.getTotalPages(_page.rows, _page.pageSize);
                        _page.currentPageNo = 1;
                    }
                    else
                    {
                        _page.currentPageNo = Lib.FindPage(action, _page.currentPageNo, _page.pages);
                    }
                    if (!isPrint)
                    {
                        int StartRow = Lib.getStartRow(_page.currentPageNo, _page.pageSize);

                        query = query
                            .Skip(StartRow)
                            .Take(_page.pageSize);
                    }

                    if (!isPrint)
                    {
                        Records = await query
                        .OrderBy(o => o.mbl_ref_date)
                        .Select(e => new rep_masterprofit_dto
                        {
                            mbl_id = e.mbl_id,
                            mbl_refno = e.mbl_refno,
                            mbl_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                            mbl_mode = e.mbl_mode,
                            mbl_no = e.mbl_no,
                            mbl_inv = "ARAP",
                            mbl_agent_id = e.mbl_agent_id,
                            mbl_agent_name = e.agent!.cust_name,
                            mbl_liner_id = e.mbl_liner_id,
                            mbl_liner_name = e.liner!.param_name,
                            mbl_ref_count = 1,          // reference count(master)
                            mbl_house_tot = e.mbl_house_tot,
                            mbl_revenue = e.mbl_revenue,
                            mbl_inc_total = e.mbl_inc_total,
                            mbl_exp_total = e.mbl_exp_total,
                            mbl_profit_per = e.mbl_per,         // profit per(cost)
                            mbl_cntr_type = e.mbl_cntr_type,
                            mbl_pcs = e.mbl_pcs,
                            mbl_teu = e.mbl_teu,
                            mbl_20 = e.mbl_20,
                            mbl_40 = e.mbl_40,
                            mbl_40hq = e.mbl_40hq,
                            mbl_45 = e.mbl_45,
                            mbl_cbm = e.mbl_cbm,
                            mbl_weight = e.mbl_weight,
                            // mbl_link = "/seaimport/seaimportmEdit",
                            // mbl_menuid = "SEA-IMPORT-M",
                            // mbl_type = "SEA-IMPORT-M",

                            rec_created_by = e.rec_created_by,
                            rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                            rec_edited_by = e.rec_edited_by,
                            rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                        }).ToListAsync();
                    }
                    if (mbl_format == "AGENT" && isPrint)
                    {
                        var agentGroups = await query
                            .Include(c => c.agent)
                            .Include(c => c.liner)
                            .Include(c => c.shipper)
                            .Include(c => c.consignee)
                            .GroupBy(g => new { g.mbl_agent_id, g.agent!.cust_name })
                            .ToListAsync();

                        foreach (var agentGroup in agentGroups)
                        {
                            var orderedGroup = agentGroup
                                .OrderBy(o => o.mbl_ref_date)
                                .ToList();

                            Records.Add(new rep_masterprofit_dto            // to add agent name (as header) row
                            {
                                IsAgentTitle = true,
                                mbl_agent_name = agentGroup.Key.cust_name,
                                mbl_house_tot = null,
                                mbl_inc_total = null,
                                mbl_exp_total = null,
                                mbl_revenue = null,
                                mbl_20 = null,
                                mbl_40 = null,
                                mbl_40hq = null,
                                mbl_45 = null,
                                mbl_teu = null,
                                mbl_cbm = null,
                                mbl_weight = null,
                            });

                            foreach (var e in orderedGroup)
                            {
                                Records.Add(new rep_masterprofit_dto
                                {
                                    mbl_refno = e.mbl_refno,
                                    mbl_no = e.mbl_no,
                                    mbl_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                                    mbl_house_tot = e.mbl_house_tot,
                                    mbl_agent_name = e.agent?.cust_name,
                                    mbl_liner_name = e.liner?.param_name,
                                    mbl_shipper_name = e.shipper?.cust_name,
                                    mbl_consignee_name = e.consignee?.cust_name,
                                    mbl_inc_total = e.mbl_inc_total,
                                    mbl_exp_total = e.mbl_exp_total,
                                    mbl_revenue = e.mbl_revenue,
                                    mbl_profit = e.mbl_revenue ?? 0,
                                    mbl_cntr_type = e.mbl_cntr_type,
                                    mbl_20 = e.mbl_20 ?? 0,
                                    mbl_40 = e.mbl_40 ?? 0,
                                    mbl_40hq = e.mbl_40hq ?? 0,
                                    mbl_45 = e.mbl_45 ?? 0,
                                    mbl_teu = e.mbl_teu ?? 0,
                                    mbl_cbm = e.mbl_cbm ?? 0,
                                    mbl_weight = e.mbl_weight ?? 0,
                                });
                            }

                            // single agent total
                            Records.Add(new rep_masterprofit_dto
                            {
                                mbl_refno = "TOTAL",
                                mbl_house_tot = agentGroup.Sum(x => x.mbl_house_tot ?? 0),
                                mbl_inc_total = agentGroup.Sum(x => x.mbl_inc_total ?? 0),
                                mbl_exp_total = agentGroup.Sum(x => x.mbl_exp_total ?? 0),
                                mbl_revenue = agentGroup.Sum(x => x.mbl_revenue ?? 0),
                                mbl_20 = agentGroup.Sum(x => x.mbl_20 ?? 0),
                                mbl_40 = agentGroup.Sum(x => x.mbl_40 ?? 0),
                                mbl_40hq = agentGroup.Sum(x => x.mbl_40hq ?? 0),
                                mbl_45 = agentGroup.Sum(x => x.mbl_45 ?? 0),
                                mbl_teu = agentGroup.Sum(x => x.mbl_teu ?? 0),
                                mbl_cbm = agentGroup.Sum(x => x.mbl_cbm ?? 0),
                                mbl_weight = agentGroup.Sum(x => x.mbl_weight ?? 0),
                            });
                        }
                    }
                    if ((mbl_format == "OPERATION GROUP" || mbl_format == "GENERAL") && isPrint)
                    {
                        var OpGroups = await query
                            .Include(c => c.agent)
                            .Include(c => c.liner)
                            .Include(c => c.shipper)
                            .Include(c => c.consignee)
                            .GroupBy(g => new { g.mbl_mode })
                            .ToListAsync();

                        foreach (var OpGroup in OpGroups)
                        {
                            var orderedGroup = OpGroup
                                .OrderBy(o => o.mbl_ref_date)
                                .ToList();
                            foreach (var e in orderedGroup)
                            {
                                Records.Add(new rep_masterprofit_dto
                                {
                                    mbl_refno = e.mbl_refno,
                                    mbl_no = e.mbl_no,
                                    mbl_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                                    mbl_house_tot = e.mbl_house_tot,
                                    mbl_cntr_type = e.mbl_cntr_type,
                                    mbl_agent_name = e.agent?.cust_name,
                                    mbl_liner_name = e.liner?.param_name,
                                    mbl_shipper_name = e.shipper?.cust_name,
                                    mbl_consignee_name = e.consignee?.cust_name,
                                    mbl_inc_total = e.mbl_inc_total,
                                    mbl_exp_total = e.mbl_exp_total,
                                    mbl_revenue = e.mbl_revenue,
                                    mbl_profit = e.mbl_revenue ?? 0,
                                    mbl_20 = e.mbl_20 ?? 0,
                                    mbl_40 = e.mbl_40 ?? 0,
                                    mbl_40hq = e.mbl_40hq ?? 0,
                                    mbl_45 = e.mbl_45 ?? 0,
                                    mbl_teu = e.mbl_teu ?? 0,
                                    mbl_cbm = e.mbl_cbm ?? 0,
                                    mbl_weight = e.mbl_weight ?? 0,
                                });
                            }

                            // single Group total
                            Records.Add(new rep_masterprofit_dto
                            {
                                mbl_refno = "TOTAL",
                                mbl_house_tot = OpGroup.Sum(x => x.mbl_house_tot ?? 0),
                                mbl_inc_total = OpGroup.Sum(x => x.mbl_inc_total ?? 0),
                                mbl_exp_total = OpGroup.Sum(x => x.mbl_exp_total ?? 0),
                                mbl_revenue = OpGroup.Sum(x => x.mbl_revenue ?? 0),
                                mbl_20 = OpGroup.Sum(x => x.mbl_20 ?? 0),
                                mbl_40 = OpGroup.Sum(x => x.mbl_40 ?? 0),
                                mbl_40hq = OpGroup.Sum(x => x.mbl_40hq ?? 0),
                                mbl_45 = OpGroup.Sum(x => x.mbl_45 ?? 0),
                                mbl_teu = OpGroup.Sum(x => x.mbl_teu ?? 0),
                                mbl_cbm = OpGroup.Sum(x => x.mbl_cbm ?? 0),
                                mbl_weight = OpGroup.Sum(x => x.mbl_weight ?? 0),
                            });
                        }
                    }
                }
                if (mbl_report_type == "SUMMARY" && mbl_format != "PARTY")
                {
                    if (mbl_format == "AGENT")
                    {
                        Records = await query
                        .GroupBy(g => new { g.mbl_agent_id, g.agent!.cust_name })
                        .Select(m => new rep_masterprofit_dto
                        {
                            mbl_agent_id = m.Key.mbl_agent_id,
                            mbl_agent_name = m.Key.cust_name,
                            mbl_ref_count = m.Count(),
                            mbl_house_tot = m.Sum(x => x.mbl_house_tot ?? 0),
                            mbl_inc_total = m.Sum(x => x.mbl_inc_total ?? 0),
                            mbl_exp_total = m.Sum(x => x.mbl_exp_total ?? 0),
                            mbl_revenue = m.Sum(x => x.mbl_revenue ?? 0),
                            mbl_profit_per = m.Sum(x => x.mbl_per ?? 0),
                            mbl_pcs = m.Sum(x => x.mbl_pcs ?? 0),
                            mbl_20 = m.Sum(x => x.mbl_20 ?? 0),
                            mbl_40 = m.Sum(x => x.mbl_40 ?? 0),
                            mbl_40hq = m.Sum(x => x.mbl_40hq ?? 0),
                            mbl_45 = m.Sum(x => x.mbl_45 ?? 0),
                            mbl_teu = m.Sum(x => x.mbl_teu ?? 0),
                            mbl_cbm = m.Sum(x => x.mbl_cbm ?? 0),
                            mbl_weight = m.Sum(x => x.mbl_weight ?? 0),
                        })
                        .OrderBy(o => o.mbl_agent_name)
                        .ToListAsync();
                    }

                    if (mbl_format == "OPERATION GROUP" || mbl_format == "GENERAL")
                    {
                        Records = await query
                        .GroupBy(g => new { g.mbl_mode })
                        .Select(m => new rep_masterprofit_dto
                        {
                            mbl_mode = m.Key.mbl_mode,
                            mbl_ref_count = m.Count(),
                            mbl_house_tot = m.Sum(x => x.mbl_house_tot ?? 0),
                            mbl_inc_total = m.Sum(x => x.mbl_inc_total ?? 0),
                            mbl_exp_total = m.Sum(x => x.mbl_exp_total ?? 0),
                            mbl_revenue = m.Sum(x => x.mbl_revenue ?? 0),
                            mbl_profit_per = m.Sum(x => x.mbl_per ?? 0),
                            mbl_pcs = m.Sum(x => x.mbl_pcs ?? 0),
                            mbl_20 = m.Sum(x => x.mbl_20 ?? 0),
                            mbl_40 = m.Sum(x => x.mbl_40 ?? 0),
                            mbl_40hq = m.Sum(x => x.mbl_40hq ?? 0),
                            mbl_45 = m.Sum(x => x.mbl_45 ?? 0),
                            mbl_teu = m.Sum(x => x.mbl_teu ?? 0),
                            mbl_cbm = m.Sum(x => x.mbl_cbm ?? 0),
                            mbl_weight = m.Sum(x => x.mbl_weight ?? 0),
                        })
                        .OrderBy(o => o.mbl_mode)
                        .ToListAsync();
                    }

                    if (action == "SEARCH" || action == "PRINT" || action == "EXCEL" || action == "PDF")
                    {
                        _page.rows = Records.Count(); // add 1 for total count if needed
                        _page.pages = Lib.getTotalPages(_page.rows, _page.pageSize);
                        _page.currentPageNo = 1;
                    }
                    else
                    {
                        _page.currentPageNo = Lib.FindPage(action, _page.currentPageNo, _page.pages);
                    }
                    if (!isPrint)
                    {
                        int StartRow = Lib.getStartRow(_page.currentPageNo, _page.pageSize);

                        Records = Records.Skip(StartRow).ToList();
                    }
                }

                if (mbl_format == "PARTY" && mbl_report_type != "SUMMARY")
                {
                    var data_ =
                        from m in query
                        join h in context.cargo_housem
                            on m.mbl_id equals h.hbl_mbl_id into houseGroup

                        from h in houseGroup.DefaultIfEmpty()
                        orderby m.mbl_refno
                        select new rep_masterprofit_dto
                        {
                            mbl_id = m.mbl_id,
                            mbl_refno = m.mbl_refno,
                            mbl_ref_date = Lib.FormatDate(m.mbl_ref_date, Lib.outputDateFormat),
                            mbl_mode = m.mbl_mode,
                            mbl_no = m.mbl_no,
                            mbl_agent_name = m.agent!.cust_name,

                            mbl_shipper_name = h != null ? h.shipper!.cust_name : null,
                            mbl_consignee_name = h != null ? h.consignee!.cust_name : null,

                            mbl_ref_count = m.mbl_house_tot,
                            mbl_inc_total = h != null ? h.hbl_inc_total_cbm : m.mbl_inc_total,
                            mbl_exp_total = h != null ? h.hbl_exp_total_cbm : m.mbl_exp_total,
                            mbl_revenue = h != null ? h.hbl_revenue_cbm : m.mbl_revenue,
                            mbl_profit_per = m.mbl_per,
                            mbl_customer_name = m.customer!.cust_name,

                            rec_created_by = h != null ? h.rec_created_by : m.rec_created_by,
                            rec_created_date = h != null ? Lib.FormatDate(h.rec_created_date, Lib.outputDateTimeFormat) : Lib.FormatDate(m.rec_created_date, Lib.outputDateTimeFormat),
                            rec_edited_by = h != null ? h.rec_edited_by : m.rec_edited_by,
                            rec_edited_date = h != null ? Lib.FormatDate(h.rec_edited_date, Lib.outputDateTimeFormat) : Lib.FormatDate(m.rec_edited_date, Lib.outputDateTimeFormat),
                        };

                    if (action == "SEARCH" || action == "PRINT" || action == "EXCEL" || action == "PDF")
                    {
                        _page.rows = data_.Count();
                        _page.pages = Lib.getTotalPages(_page.rows, _page.pageSize);
                        _page.currentPageNo = 1;
                    }
                    else
                    {
                        _page.currentPageNo = Lib.FindPage(action, _page.currentPageNo, _page.pages);
                    }

                    if (!isPrint)
                    {
                        int StartRow = Lib.getStartRow(_page.currentPageNo, _page.pageSize);
                        data_ = data_.Skip(StartRow).Take(_page.pageSize);                      // if data_ added ( count master wise)
                    }
                   Records = await data_.ToListAsync();
                }

                if (_page.currentPageNo == _page.pages || (action == "PRINT" && Records.Count() != 0))
                    Records.Add(totalRow);

                RetData.Add("records", Records);

                if (action == "PDF" || action == "PRINT")
                {
                    var pdfResult = ProcessPdfFileAsync(Records, title!, company_id, user_name!, branch_id, searchInfo);
                    fileDataList.Add(pdfResult);
                }
                if (action == "EXCEL" || action == "PRINT")
                {
                    var excelResult = ProcessExcelFileAsync(Records, title!, company_id, user_name!, branch_id, searchInfo);
                    fileDataList.Add(excelResult);
                }

                RetData.Add("fileData", fileDataList);
                RetData.Add("action", action);
                RetData.Add("page", _page);

                return RetData;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public filesm ProcessPdfFileAsync(List<rep_masterprofit_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Print List Not Found");

            var record = new filesm();
            if(searchInfo["mbl_report_type"] == "MASTER")
            {
                MasterProfitDetPdfFile bc = new MasterProfitDetPdfFile
                {
                    Dt_List = Dt_List,
                    Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                    Title = title,
                    Company_id = company_id,
                    Branch_id = branch_id,
                    context = context,
                    User_name = user_name,
                    FromDate = searchInfo.ContainsKey("mbl_from_date") ? searchInfo["mbl_from_date"] : "",
                    ToDate = searchInfo.ContainsKey("mbl_to_date") ? searchInfo["mbl_to_date"] : "",
                    OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
                    Format = searchInfo.ContainsKey("mbl_format") ? searchInfo["mbl_format"] : "",
                    ReportType = searchInfo.ContainsKey("mbl_report_type") ? searchInfo["mbl_report_type"] : "",
                    Salesman = searchInfo.ContainsKey("mbl_salesman_name") ? searchInfo["mbl_salesman_name"] : "",
                    Parent = searchInfo.ContainsKey("mbl_parent_name") ? searchInfo["mbl_parent_name"] : "",
                    Agent = searchInfo.ContainsKey("mbl_agent_name") ? searchInfo["mbl_agent_name"] : "",
                    PartyName = searchInfo.ContainsKey("mbl_customer_name") ? searchInfo["mbl_customer_name"] : "",
                    ProfitCriteria = searchInfo.ContainsKey("mbl_profit_criteria") ? searchInfo["mbl_profit_criteria"] : "",
                    ProfitVal = searchInfo.ContainsKey("mbl_profit_val") ? searchInfo["mbl_profit_val"] : "",
                };
                bc.Process();
                if (bc.FList == null || !bc.FList.Any())
                throw new Exception("File generation failed.");

                var file = bc.FList[0];

                record = new filesm
                {
                    filepath = file.filename!,
                    filename = file.filedisplayname!,
                    filetype = file.filetype!
                };
            }
            if(searchInfo["mbl_report_type"] == "SUMMARY")
            {
                MasterProfitSummaryPdfFile bc = new MasterProfitSummaryPdfFile
                {
                    Dt_List = Dt_List,
                    Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                    Title = title,
                    Company_id = company_id,
                    Branch_id = branch_id,
                    context = context,
                    User_name = user_name,
                    FromDate = searchInfo.ContainsKey("mbl_from_date") ? searchInfo["mbl_from_date"] : "",
                    ToDate = searchInfo.ContainsKey("mbl_to_date") ? searchInfo["mbl_to_date"] : "",
                    OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
                    Format = searchInfo.ContainsKey("mbl_format") ? searchInfo["mbl_format"] : "",
                    ReportType = searchInfo.ContainsKey("mbl_report_type") ? searchInfo["mbl_report_type"] : "",
                    Salesman = searchInfo.ContainsKey("mbl_salesman_name") ? searchInfo["mbl_salesman_name"] : "",
                    Parent = searchInfo.ContainsKey("mbl_parent_name") ? searchInfo["mbl_parent_name"] : "",
                    Agent = searchInfo.ContainsKey("mbl_agent_name") ? searchInfo["mbl_agent_name"] : "",
                    PartyName = searchInfo.ContainsKey("mbl_customer_name") ? searchInfo["mbl_customer_name"] : "",
                };
                bc.Process();
                if (bc.FList == null || !bc.FList.Any())
                throw new Exception("File generation failed.");

                var file = bc.FList[0];

                record = new filesm
                {
                    filepath = file.filename!,
                    filename = file.filedisplayname!,
                    filetype = file.filetype!
                };
            }
            return record;
        }
        public filesm ProcessExcelFileAsync(List<rep_masterprofit_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");
            
            var record = new filesm();
            if(searchInfo["mbl_report_type"] == "MASTER")
            {
                MasterProfitDetExcelFile bc = new MasterProfitDetExcelFile
                {
                    Dt_List = Dt_List,
                    report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                    Title = title,
                    Company_id = company_id,
                    Branch_id = branch_id,
                    context = context,
                    User_name = user_name,
                    FromDate = searchInfo.ContainsKey("mbl_from_date") ? searchInfo["mbl_from_date"] : "",
                    ToDate = searchInfo.ContainsKey("mbl_to_date") ? searchInfo["mbl_to_date"] : "",
                    OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
                    Format = searchInfo.ContainsKey("mbl_format") ? searchInfo["mbl_format"] : "",
                    ReportType = searchInfo.ContainsKey("mbl_report_type") ? searchInfo["mbl_report_type"] : "",
                    Salesman = searchInfo.ContainsKey("mbl_salesman_name") ? searchInfo["mbl_salesman_name"] : "",
                    Parent = searchInfo.ContainsKey("mbl_parent_name") ? searchInfo["mbl_parent_name"] : "",
                    Agent = searchInfo.ContainsKey("mbl_agent_name") ? searchInfo["mbl_agent_name"] : "",
                    PartyName = searchInfo.ContainsKey("mbl_customer_name") ? searchInfo["mbl_customer_name"] : "",
                    ProfitCriteria = searchInfo.ContainsKey("mbl_profit_criteria") ? searchInfo["mbl_profit_criteria"] : "",
                    ProfitVal = searchInfo.ContainsKey("mbl_profit_val") ? searchInfo["mbl_profit_val"] : "",
                };
                bc.Process();

                if (bc.fList == null || !bc.fList.Any())
                    throw new Exception("Excel generation failed.");

                var file = bc.fList[0];

                record = new filesm
                {
                    filepath = file.filename!,
                    filename = file.filedisplayname!,
                    filetype = file.filetype!
                };
            }
            if(searchInfo["mbl_report_type"] == "SUMMARY")
            {
                    MasterProfitSummaryExcelFile bc = new MasterProfitSummaryExcelFile
                {
                    Dt_List = Dt_List,
                    report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                    Title = title,
                    Company_id = company_id,
                    Branch_id = branch_id,
                    context = context,
                    User_name = user_name,
                    FromDate = searchInfo.ContainsKey("mbl_from_date") ? searchInfo["mbl_from_date"] : "",
                    ToDate = searchInfo.ContainsKey("mbl_to_date") ? searchInfo["mbl_to_date"] : "",
                    OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
                    Format = searchInfo.ContainsKey("mbl_format") ? searchInfo["mbl_format"] : "",
                    ReportType = searchInfo.ContainsKey("mbl_report_type") ? searchInfo["mbl_report_type"] : "",
                    Salesman = searchInfo.ContainsKey("mbl_salesman_name") ? searchInfo["mbl_salesman_name"] : "",
                    Parent = searchInfo.ContainsKey("mbl_parent_name") ? searchInfo["mbl_parent_name"] : "",
                    Agent = searchInfo.ContainsKey("mbl_agent_name") ? searchInfo["mbl_agent_name"] : "",
                    PartyName = searchInfo.ContainsKey("mbl_customer_name") ? searchInfo["mbl_customer_name"] : "",
                };
                bc.Process();

                if (bc.fList == null || !bc.fList.Any())
                    throw new Exception("Excel generation failed.");

                var file = bc.fList[0];

                record = new filesm
                {
                    filepath = file.filename!,
                    filename = file.filedisplayname!,
                    filetype = file.filetype!
                };
            }
            return record;
        }
    }
}