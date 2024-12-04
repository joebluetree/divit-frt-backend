using Database.Models.BaseTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Tnt
{


    public class DateInfo
    {
        public DateTime Date { get; set; }
        public bool IsActual { get; set; }
    }

    public class TSPort
    {
        public string? Port { get; set; }
        public DateInfo? ArrivalDate { get; set; }
        public DateInfo? DepartureDate { get; set; }
        public string? Vessel { get; set; }
        public string? VesselIMO { get; set; }
        public double VesselLatitude { get; set; }
        public double VesselLongitude { get; set; }
        public string? VesselVoyage { get; set; }
    }

    public class TrackingEvent_ShipsGo
    {
        public string? Message { get; set; }
        public string? Status { get; set; }
        public int StatusId { get; set; }
        public string? ReferenceNo { get; set; }
        public string? BLReferenceNo { get; set; }
        public string? ShippingLine { get; set; }
        public string? ContainerNumber { get; set; }
        public string? ContainerTEU { get; set; }
        public string? ContainerType { get; set; }
        public string? FromCountry { get; set; }
        public string? Pol { get; set; }
        public DateInfo? LoadingDate { get; set; }
        public DateInfo? DepartureDate { get; set; }
        public List<TSPort>? TSPorts { get; set; }
        public string? ToCountry { get; set; }
        public string? Pod { get; set; }
        public DateInfo? ArrivalDate { get; set; }
        public DateInfo? DischargeDate { get; set; }
        public string? Vessel { get; set; }
        public string? VesselIMO { get; set; }
        public string? VesselLatitude { get; set; }
        public string? VesselLongitude { get; set; }
        public string? VesselVoyage { get; set; }
        public string? EmptyToShipperDate { get; set; }
        public string? GateInDate { get; set; }
        public string? GateOutDate { get; set; }
        public string? EmptyReturnDate { get; set; }
        public string? FormatedTransitTime { get; set; }
        public string? ETA { get; set; }
        public string? FirstETA { get; set; }
        public int BLContainerCount { get; set; }
        public List<object>? BLContainers { get; set; }
        public string? LiveMapUrl { get; set; }
        public List<object>? Tags { get; set; }
        public string? Co2Emission { get; set; }
    }


}
