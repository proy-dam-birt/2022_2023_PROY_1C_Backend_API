using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.Domain.Entities.DB
{
    public class GastronomiaEuskadiTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GastroId { get; set; }
        public int? ActividadesId { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentDescription { get; set; }
        public string? TemplateType { get; set; }
        public string? Locality { get; set; }
        public string? QualityQ { get; set; }
        public string? QualityIconDescription { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Marks { get; set; }
        public string? Physical { get; set; }
        public string? Visual { get; set; }
        public string? Auditive { get; set; }
        public string? Intellectual { get; set; }
        public string? Organic { get; set; }
        public string? QualityAssurance { get; set; }
        public string? TourismEmail { get; set; }
        public string? Web { get; set; }
        public string? Room { get; set; }
        public string? ProductClub { get; set; }
        public string? Visit { get; set; }
        public string? Capacity { get; set; }
        public string? Store { get; set; }
        public string? PostalCode { get; set; }
        public string? RestorationType { get; set; }
        public string? Recomended { get; set; }
        public string? RecomendedURLIcon { get; set; }
        public string? RecomendedIconDescription { get; set; }
        public string? Restaurant { get; set; }
        public string? Bodega { get; set; }
        public string? MichelinStar { get; set; }
        public string? RepsolSun { get; set; }
        public string? Latitudelongitude { get; set; }
        public string? Latwgs84 { get; set; }
        public string? Lonwgs84 { get; set; }
        public string? Municipality { get; set; }
        public string? Municipalitycode { get; set; }
        public string? Territory { get; set; }
        public string? Territorycode { get; set; }
        public string? Country { get; set; }
        public string? Countrycode { get; set; }
        public string? FriendlyUrl { get; set; }
        public string? PhysicalUrl { get; set; }
        public string? DataXML { get; set; }
        public string? MetadataXML { get; set; }
        public string? ZipFile { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
