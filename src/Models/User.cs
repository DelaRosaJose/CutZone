namespace CutZone.Models
{
    public class User : BaseModel
    {
        public string Name
        {
            get => Get<string>();
            set => Set(value);
        }
        public string Password
        {
            get => Get<string>();
            set => Set(value);
        }

    }
}

