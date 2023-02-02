using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DB
{
    public class EventoEuskadiTable
    {
        
        
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int EventoEuskadiId { get; set; }

            [Required]
            [ForeignKey("EventsIdFK")]
            public int EventsId { get; set; }
            public EventsTable EventsTable { get; set; }
            public int? ActividadesId { get; set; }
            public string? CompanyEs { get; set; }
            public string? CompanyEu { get; set; }
            public string? DescriptionEs { get; set; }
            public string? DescriptionEu { get; set; }
            public string? EndDate { get; set; }
            public string? EstablishmentEs { get; set; }
            public string? EstablishmentEu { get; set; }
            public string? Ids { get; set; }
            public IList<ImagesTable>? Images { get; } = new List<ImagesTable>();       // Collection navigation
            public string? Language { get; set; }
            public string? MunicipalityEs { get; set; }
            public string? MunicipalityEu { get; set; }
            public string? MunicipalityLatitude { get; set; }
            public string? MunicipalityLongitude { get; set; }
            public string? MunicipalityNoraCode { get; set; }
            public string? NameEs { get; set; }
            public string? NameEu { get; set; }
            public string? Online { get; set; }
            public string? OpeningHours { get; set; }
            public string? OpeningHoursEu { get; set; }
            public string? PlaceEs { get; set; }
            public string? PlaceEu { get; set; }
            public string? PriceEu { get; set; }
            public string? ProvinceNoraCode { get; set; }
            public string? PublicationDate { get; set; }
            public string? PurchaseUrlEs { get; set; }
            public string? PurchaseUrlEu { get; set; }
            public string? SourceNameEs { get; set; }
            public string? SourceNameEu { get; set; }
            public string? SourceUrlEs { get; set; }
            public string? SourceUrlEu { get; set; }
            public string? StartDate { get; set; }
            public string? Type { get; set; }
            public string? TypeEs { get; set; }
            public string? TypeEu { get; set; }
            public string? UrlEventEs { get; set; }
            public string? UrlEventEu { get; set; }
            public string? UrlNameEs { get; set; }
            public string? UrlNameEu { get; set; }
            public string? UrlOnline { get; set; }
            public string? UrlOnlineEu { get; set; }
            public DateTime CreatedDateTime { get; set; }
            public DateTime UpdatedDateTime { get; set; }

            public void Update(EventoEuskadiTable src)
            {
                if (src == null)
                    throw new ArgumentNullException("Source orderline is null");

                this.CompanyEs = CompanyEs;
                this.CompanyEu = CompanyEu;
                this.DescriptionEs = DescriptionEs;
                this.DescriptionEu = DescriptionEu;
                this.EndDate = EndDate;
                this.EstablishmentEs = EstablishmentEs;
                this.EstablishmentEu = EstablishmentEu;
                this.Ids = Ids;
                //this.Images = Images; 
                this.Language = Language;
                this.MunicipalityEs = MunicipalityEs;
                this.MunicipalityEu = MunicipalityEu;
                this.MunicipalityLatitude = MunicipalityLatitude;
                this.MunicipalityLongitude = MunicipalityLongitude;
                this.MunicipalityNoraCode = MunicipalityNoraCode;
                this.NameEs = NameEs;
                this.NameEu = NameEu;
                this.Online = Online;
                this.OpeningHours = OpeningHours;
                this.OpeningHoursEu = OpeningHoursEu;
                this.PlaceEs = PlaceEs;
                this.PlaceEu = PlaceEu;
                this.PriceEu = PriceEu;
                this.ProvinceNoraCode = ProvinceNoraCode;
                this.PublicationDate = PublicationDate;
                this.PurchaseUrlEs = PurchaseUrlEs;
                this.PurchaseUrlEu = PurchaseUrlEu;
                this.SourceNameEs = SourceNameEs;
                this.SourceNameEu = SourceNameEu;
                this.SourceUrlEs = SourceUrlEs;
                this.SourceUrlEu = SourceUrlEu;
                this.StartDate = StartDate;
                this.Type = Type;
                this.TypeEs = TypeEs;
                this.TypeEu = TypeEu;
                this.UrlEventEs = UrlEventEs;
                this.UrlEventEu = UrlEventEu;
                this.UrlNameEs = UrlNameEs;
                this.UrlNameEu = UrlNameEu;
                this.UrlOnline = UrlOnline;
                this.UrlOnlineEu = UrlOnlineEu;
                this.UpdatedDateTime = DateTime.Now;
            }
        }
    }
