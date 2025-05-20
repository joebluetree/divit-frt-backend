using Database;
using Database.Lib;
using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.BaseTables;
using UserAdmin.Interfaces;
using Database.Models.UserAdmin;
using Common.DTO.UserAdmin;
using Common.Lib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;


namespace UserAdmin.Repositories
{

    //Name : Alen Cherian
    //Date : 06/05/2025
    //Command :  Create Repository for the File Upload.

    public class FileUploadmRepository : IFileUploadmRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;
        public FileUploadmRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var company_id = 0;
                var branch_id = 0;

                if (data.ContainsKey("rec_company_id"))
                    company_id = int.Parse(data["rec_company_id"].ToString()!);
                if (company_id == 0)
                    throw new Exception("Company Id Not Found");

                if (data.ContainsKey("rec_branch_id"))
                    branch_id = int.Parse(data["rec_branch_id"].ToString()!);
                if (branch_id == 0)
                    throw new Exception("Branch Id Not Found");

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<mast_fileupload> query = context.mast_fileupload;

                query = query.Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id);


                if (action == "SEARCH")
                {
                    _page.rows = query.Count();
                    _page.pages = Lib.getTotalPages(_page.rows, _page.pageSize);
                    _page.currentPageNo = 1;
                }
                else
                {
                    _page.currentPageNo = Lib.FindPage(action, _page.currentPageNo, _page.pages);
                }

                int StartRow = Lib.getStartRow(_page.currentPageNo, _page.pageSize);

                query = query
                    .OrderBy(c => c.files_id)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new mast_fileupload_dto
                {
                    files_id = e.files_id,
                    files_parent_id = e.files_parent_id,
                    files_slno = e.files_slno,
                    files_type = e.files_type,
                    files_desc = e.files_desc,
                    files_ref_no = e.files_ref_no,
                    files_path = e.files_path,
                    files_sub_id = e.files_sub_id,
                    files_size = e.files_size,
                    files_processed = e.files_processed,
                    files_status = e.files_status,
                    rec_deleted_by = e.rec_deleted_by,
                    rec_deleted_date = Lib.FormatDate(e.rec_deleted_date, Lib.outputDateTimeFormat),

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).ToListAsync();

                RetData.Add("records", Records);
                RetData.Add("page", _page);

                return RetData;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<mast_fileupload_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<mast_fileupload> query = context.mast_fileupload;
                query = query.Where(f => f.files_id == id);

                var Record = await query.Select(e => new mast_fileupload_dto
                {
                    files_id = e.files_id,
                    files_parent_id = e.files_parent_id,
                    files_slno = e.files_slno,
                    files_type = e.files_type,
                    files_desc = e.files_desc,
                    files_ref_no = e.files_ref_no,
                    files_path = e.files_path,
                    files_sub_id = e.files_sub_id,
                    files_size = e.files_size,
                    files_processed = e.files_processed,
                    files_status = e.files_status,
                    rec_deleted_by = e.rec_deleted_by,
                    rec_deleted_date = Lib.FormatDate(e.rec_deleted_date, Lib.outputDateTimeFormat),

                    rec_version = e.rec_version,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Data Found");

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<List<mast_fileupload_dto>> GetDetailsAsync(int id, string parent_type, string? files_status)
        {
            // Base query
            var baseQuery = context.mast_fileupload
                .Where(e => e.files_parent_id == id && e.files_parent_type == parent_type);

            // If files_status is not "D", filter only active records
            if (files_status != "D")
            {
                baseQuery = baseQuery.Where(e => e.files_status == "N"); // Adjust "N" to match your active flag
            }

            // Now project to DTO
            var query = from e in baseQuery.OrderBy(e => e.files_slno)
                        select new mast_fileupload_dto
                        {
                            files_id = e.files_id,
                            files_parent_id = e.files_parent_id,
                            files_slno = e.files_slno,
                            files_type = e.files_type,
                            files_desc = e.files_desc,
                            files_ref_no = e.files_ref_no,
                            files_path = e.files_path,
                            files_sub_id = e.files_sub_id,
                            files_size = e.files_size,
                            files_processed = e.files_processed,
                            files_status = e.files_status,
                            rec_deleted_by = e.rec_deleted_by,
                            rec_deleted_date = Lib.FormatDate(e.rec_deleted_date, Lib.outputDateTimeFormat),

                            rec_version = e.rec_version,
                            rec_branch_id = e.rec_branch_id,
                            rec_company_id = e.rec_company_id,
                            rec_created_by = e.rec_created_by,
                            rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                            rec_edited_by = e.rec_edited_by,
                            rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                        };

            var record = await query.ToListAsync();
            return record;
        }


        public async Task<mast_fileupload_dto?> GetDefaultDataAsync(int id, string parent_type)
        {
            try
            {
                var query = context.cargo_masterm
                    .Where(f => f.mbl_id == id && f.mbl_mode == parent_type);

                var Record = await query
                    .Select(e => new mast_fileupload_dto
                    {
                        files_parent_id = e.mbl_id,
                        files_ref_no = e.mbl_refno,
                        files_parent_type = e.mbl_mode,
                        rec_branch_id = e.rec_branch_id,
                        rec_company_id = e.rec_company_id,
                    })
                    .FirstOrDefaultAsync();


                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }


        public async Task<mast_fileupload_dto> SaveAsync(int id, string mode, mast_fileupload_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();
                context.Database.BeginTransaction();
                record_dto = await SaveParentAsync(id, mode, record_dto);
                context.Database.CommitTransaction();
                return record_dto;
            }
            catch (DbUpdateConcurrencyException)
            {
                context.Database.RollbackTransaction();
                throw new Exception("Kindly reload the record, Another User May have modified the same record");
            }
            catch (Exception)
            {
                context.Database.RollbackTransaction();
                throw;
            }
        }
        private Boolean AllValid(string mode, mast_fileupload_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";
            if (Lib.IsBlank(record_dto.files_type))
                str += "Document Type Cannot Be Blank!";

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }
            return bRet;
        }

        public async Task<mast_fileupload_dto> SaveParentAsync(int id, string mode, mast_fileupload_dto record_dto)
        {
            mast_fileupload? Record;
            string error = "";
            try
            {
                var DefaultCfNo = 1;
                int iNextNo = GetNextCfNo(record_dto.rec_company_id, record_dto.rec_branch_id, DefaultCfNo);

                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {

                    Record = new mast_fileupload();
                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();


                    Record.files_parent_id = record_dto.files_parent_id;
                    Record.files_slno = iNextNo;
                    Record.files_parent_type = record_dto.files_parent_type;
                }
                else
                {
                    Record = await context.mast_fileupload
                        .Where(f => f.files_id == id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("Record Not Found");

                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;
                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }
                if (mode == "edit")
                    await logHistory(Record, record_dto);

                Record.files_type = record_dto.files_type;
                Record.files_desc = record_dto.files_desc;
                Record.files_ref_no = record_dto.files_ref_no;
                Record.files_path = record_dto.files_path;
                Record.files_sub_id = record_dto.files_sub_id;
                Record.files_size = record_dto.files_size;
                Record.files_processed = record_dto.files_processed;
                Record.files_status = record_dto.files_status;

                if (mode == "add")
                    await context.mast_fileupload.AddAsync(Record);
                context.SaveChanges();
                record_dto.files_id = Record.files_id;
                record_dto.files_parent_id = Record.files_parent_id;
                record_dto.rec_version = Record.rec_version;
                //Lib.AssignDates2DTO(id, mode, Record, record_dto);
                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                if (record_dto.files_id != 0)
                {
                    record_dto.rec_edited_by = Record.rec_edited_by;
                    record_dto.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                }

                return record_dto;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<List<mast_fileupload_dto>> UploadFilesAsync(List<IFormFile> files, mast_fileupload_dto record_dto)
        {
            List<mast_fileupload_dto> uploadedFiles = new List<mast_fileupload_dto>();

            try
            {
                if (files == null || files.Count == 0)
                    throw new Exception("No files uploaded");

                if (Lib.IsBlank(record_dto.files_type))
                    throw new Exception("Document Type Cannot be Blank");

                DateTime? parsedDate = DbLib.GetDateTime();
                if (parsedDate == null)
                    throw new Exception("Creation date is required");

                string rootFolder = @"D:\files\2025";
                string subFolder = parsedDate.Value.ToString("MMM-yyyy").ToLower();

                foreach (var file in files)
                {
                    // Step 1: Build file-specific DTO
                    var fileDto = new mast_fileupload_dto
                    {
                        rec_company_id = record_dto.rec_company_id,
                        rec_branch_id = record_dto.rec_branch_id,
                        rec_created_by = record_dto.rec_created_by,
                        files_parent_id = record_dto.files_parent_id,
                        files_parent_type = record_dto.files_parent_type,
                        files_ref_no = record_dto.files_ref_no,
                        files_type = record_dto.files_type,
                        files_desc = file.FileName,
                        files_sub_id = record_dto.files_sub_id,
                        files_processed = "N",
                        files_size = file.Length.ToString(),
                        files_status = "N",
                    };

                    // Step 2: Save parent record
                    var savedDto = await SaveParentAsync(0, "add", fileDto);
                    int newFilesId = savedDto.files_id;

                    // Step 3: Create folder for this file using files_id
                    string targetFolder = Path.Combine(rootFolder, subFolder, newFilesId.ToString());
                    if (!Directory.Exists(targetFolder))
                        Directory.CreateDirectory(targetFolder);

                    string filePath = Path.Combine(targetFolder, file.FileName);

                    // Step 4: Save file to disk
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Step 5: Update DB record with path and metadata
                    var record = await context.mast_fileupload.FirstOrDefaultAsync(x => x.files_id == newFilesId);
                    if (record != null)
                    {
                        record.files_path = filePath;
                        // record.files_type = Path.GetExtension(file.FileName);
                        record.files_size = (file.Length / 1024.0).ToString("F2") + " KB";
                        record.files_processed = "N";
                        record.rec_created_date = parsedDate.Value;
                    }

                    uploadedFiles.Add(savedDto);
                }

                await context.SaveChangesAsync();
                return uploadedFiles;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<Dictionary<string, object>> GetDownloadFileAsync(int fileId)
        {
            var record = await context.mast_fileupload.FirstOrDefaultAsync(f => f.files_id == fileId);
            if (record == null || string.IsNullOrEmpty(record.files_path) || !System.IO.File.Exists(record.files_path))
            {
                throw new FileNotFoundException("File not found.");
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(record.files_path, FileMode.Open, FileAccess.Read))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            var contentType = "application/octet-stream";
            new FileExtensionContentTypeProvider().TryGetContentType(record.files_path, out contentType);

            return new Dictionary<string, object>
            {
                { "FileStream", memory },
                { "FileName", Path.GetFileName(record.files_path) },
                { "ContentType", contentType! }
            };
        }

        public int GetNextCfNo(int company_id, int? branch_id, int defaultCfNo)
        {
            int cfNo = context.mast_fileupload
                .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id)
                .Select(e => e.files_slno)
                .DefaultIfEmpty()
                .Max() ?? 0;
            return cfNo == 0 ? defaultCfNo : cfNo + 1;
        }

        public async Task<Dictionary<string, object>> DeleteDetailsAsync(int id, mast_fileupload_dto record_dto)
        {
            try
            {

                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.mast_fileupload
                    .Where(f => f.files_id == id)
                    .FirstOrDefaultAsync();

                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    _Record.files_status = "D";
                    _Record.rec_deleted_by = record_dto.rec_deleted_by;
                    _Record.rec_deleted_date = DbLib.GetDateTime();
                    // context.Remove(_Record);
                    await context.SaveChangesAsync();

                    RetData.Add("status", true);
                    RetData.Add("message", "");
                }
                return RetData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                context.Database.BeginTransaction();

                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.mast_fileupload
                    .Where(f => f.files_id == id)
                    .FirstOrDefaultAsync();

                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    context.Remove(_Record);
                    await context.SaveChangesAsync();

                    context.Database.CommitTransaction();

                    RetData.Add("status", true);
                    RetData.Add("message", "");
                }
                return RetData;
            }
            catch (Exception)
            {
                context.Database.RollbackTransaction();
                throw;
            }
        }

        public async Task logHistory(mast_fileupload old_record, mast_fileupload_dto record_dto)
        {

            var old_record_dto = new mast_fileupload_dto
            {
                files_id = old_record.files_id,
                files_parent_type = old_record.files_parent_type,
                files_slno = old_record.files_slno,
                files_type = old_record.files_type,
                files_desc = old_record.files_desc,
                files_ref_no = old_record.files_ref_no,
                files_path = old_record.files_path,
                files_size = old_record.files_size,
                files_processed = old_record.files_processed,

            };

            await new LogHistorym<mast_fileupload_dto>(context)
                .Table("mast_fileUpload", log_date)
                .PrimaryKey("files_id", record_dto.files_id)
                .RefNo(record_dto.files_desc!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0, record_dto.rec_created_by!)
                .TrackColumn("files_parent_type", "Parent Type")
                .TrackColumn("files_slno", "Serial No")
                .TrackColumn("files_type", "Doc Type")
                .TrackColumn("files_desc", "Description")
                .TrackColumn("files_ref_no", "Reference No")
                .TrackColumn("files_path", "File Path")
                .TrackColumn("files_size", "File Size")
                .TrackColumn("files_processed", "Is Processed")


                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();

        }

    }
}
