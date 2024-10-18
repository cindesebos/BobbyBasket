namespace Sources.Services.Master
{
    public interface IMasterService
    {
        float Volume { get; set; }
        void Save();
        void Load();
    }
}