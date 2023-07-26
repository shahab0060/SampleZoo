using System.ComponentModel.DataAnnotations;

namespace SampleZoo.Domain.Entities.Common
{
    public class EntityId<T> where T : struct
    {
        public EntityId()
        {
            //ef constructor
        }

        [Key]
        public T Id { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime LatestEditDate { get; set; } = DateTime.Now;

        public DateTime? DeletedOn { get; set; }

        public int EditCounts { get; set; }

        public bool IsDelete { get; set; }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeletedOn = DateTime.Now;
        }

        public void BaseUpdate()
        {
            this.LatestEditDate = DateTime.Now;
            this.EditCounts += 1;
        }
    }

}
