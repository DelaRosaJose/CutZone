
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CutZone.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
      
        public int Id { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string FormatedDate { get; set; } = DateTime.Now.ToString("M/dd/yyyy h:m:ss tt");



        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Dictionary<string, object> Dictionary;
        public BaseModel() => Dictionary = new Dictionary<string, object>();

        protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public void Set<T>(T value, [CallerMemberName] string propertyName = null, bool siempreNotificar = false)
        {
            T backingStore = default;

            if (Dictionary.TryGetValue(propertyName, out var valueInDict))
            {
                backingStore = (T)valueInDict;
                Dictionary[propertyName] = value;
            }
            else
                Dictionary.Add(propertyName, value);

            if (siempreNotificar || !EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                var notify = typeof(T) != typeof(string) || new string[] { (string)(object)backingStore, (string)(object)value }.Any(x => !string.IsNullOrWhiteSpace(x));

                if (notify)
                    OnPropertyChanged(propertyName);
            }

        }

        public T Get<T>([CallerMemberName] string propertyName = null)
        {
            if (Dictionary.TryGetValue(propertyName, out var valueInDict))
                return (T)valueInDict;
            else
                return default;
        }
    }
}
