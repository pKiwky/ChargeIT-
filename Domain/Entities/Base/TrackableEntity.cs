using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities {

    public class TrackableEntity : BaseEntity {
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [Column("updated_date")]
        public DateTime? UpdatedDate { get; set; }
    }


}