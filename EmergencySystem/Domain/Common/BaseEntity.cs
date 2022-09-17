namespace Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateTime { get; set; }
        public BaseEntity()
        {
            DateTime = DateTime.UtcNow;
        }



        public void SetDefaultIsDeleted()
        {
            IsDeleted = false;
        }



    }
}
