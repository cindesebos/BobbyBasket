using Zenject;
using Sources.Services.SaveLoad;

namespace Sources.Services.Master
{
    public class MasterService : IMasterService
    {
        private readonly ISaveLoadService _saveLoadService;

        private float _volume;

        [Inject]
        public MasterService(ISaveLoadService saveLoadService) => _saveLoadService = saveLoadService;

        public float Volume
        {
            get => _volume;
            set
            {
                _volume = value;

                Save();
            }
        }

        public void Save()
        {
            MasterData data = new MasterData(Volume);
            _saveLoadService.Save(data);
        }

        public void Load()
        {
            MasterData data = _saveLoadService.LoadMasterData();

            Volume = data != null ? data.GetVolume() : 0;
        }
    }
}