using System.ComponentModel.DataAnnotations;


namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }

        [StringLength(250)]
        public string AboutDetails1 { get; set; }

        [StringLength(250)]
        public string AboutDetails2 { get; set; }

        [StringLength(100)]
        public string AboutImage { get; set; }
    }
}






