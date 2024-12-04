using Database.Models.BaseTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Tnt
{
    public class TrackingEvent_Ver_1
    {
        public string? eventID { get; set; }
        public DateTimeOffset eventDateTime { get; set; }
        public string? eventTypeCode { get; set; }
        public string? eventClassifierCode { get; set; }
        public string? equipmentReference { get; set; }
        public string? facilityTypeCode { get; set; }
        public string? UNLocationCode { get; set; }
        public string? facilityCode { get; set; }
        public string? otherFacility { get; set; }
        public string? emptyIndicatorCode { get; set; }
        public string? transportReference { get; set; }
        public string? transportLegReference { get; set; }
        public string? modeOfTransportCode { get; set; }
    }

    public class TrackingEvent
    {
        public DateTimeOffset eventCreatedDateTime { get; set; }
        public string? eventType { get; set; }
        public string? eventClassifierCode { get; set; }
        public DateTimeOffset eventDateTime { get; set; }
        public string? transportEventTypeCode { get; set; }
        public TransportCall? transportCall { get; set; }
        public string? equipmentEventTypeCode { get; set; }
        public string? equipmentReference { get; set; }
        public string? ISOEquipmentCode { get; set; }
        public string? emptyIndicatorCode { get; set; }
        public EventLocation? eventLocation { get; set; }
        public string? shipmentEventTypeCode { get; set; }
        public string? documentTypeCode { get; set; }
        public string? documentID { get; set; }
    }

    public class TransportCall
    {
        public string? transportCallId { get; set; }
        public string? modeOfTransport { get; set; }
        public string? UNLocationCode { get; set; }
        public string? facilityCode { get; set; }
        public string? facilityCodeListProvider { get; set; }
        public string? facilityTypeCode { get; set; }
        public Location? location { get; set; }
        public Vessel? vessel { get; set; }
        public string? importVoyageNumber { get; set; }
        public string? exportVoyageNumber { get; set; }
    }

    public class Location
    {
        public string? UNLocationCode { get; set; }
        public string? locationName { get; set; }
        public Address? address { get; set; }
    }

    public class Address
    {
        public string? name { get; set; }
    }

    public class Vessel
    {
        public string? vesselName { get; set; }
        public string? vesselIMONumber { get; set; }
    }

    public class EventLocation
    {
        public string? UNLocationCode { get; set; }
        public string? locationName { get; set; }
        public Address? address { get; set; }
    }


    public class access_token_event
    {
        public string? access_token { get; set; }
        public string? scope { get; set; }
        public string? id_token { get; set; }
        public string? token_type { get; set; }
        public int expires_in { get; set; }

    }


}
