using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreadmakerReport.Models
{
    public class Breadmaker
    {
        [Key]
        [Column("asin")]
        public string BreadmakerId { get; set; }
        public string title { get; set; }
        public string brand { get; set; }
        public string price { get; set; }

        public List<Review> Reviews { get; set; }
    }

    public class Review
    {
        [Key]
        [Column("review_id")]
        public int reviewId { get; set; }

        [Column("breadmaker_asin")]
        public string BreadmakerId { get; set; }

        public int stars { get; set; }
    }
}
