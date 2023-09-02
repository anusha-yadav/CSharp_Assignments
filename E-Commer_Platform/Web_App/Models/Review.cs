namespace Web_App.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Rate { get; set; }
        public Nullable<System.DateTime>DateRated { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
