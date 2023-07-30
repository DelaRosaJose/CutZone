using SQLite;

namespace CutZone.Models
{
    public class BaseModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string FormatedDate { get; set; } = DateTime.Now.ToString("M/dd/yyyy h:m:ss tt");
    }
}
