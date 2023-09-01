namespace uMod.Plugins
{
    [Info("Sauvegarde automatique", "Maxime GUINARD", "1.0.0")]
    [Description("Sauvegarde automatiquement le serveur toutes les X secondes")]
    public class AutoSave : Plugin
    {
        private DefaultConfig config;

        [Config, Toml]
        private class DefaultConfig
        {
            public bool Enabled = true;
            public int Interval = 300;
        }

        private void OnServerInitialized(DefaultConfig defaultConfig)
        {
            config = defaultConfig;

            timer.Every(config.Interval, () =>
            {
                Server.Save();
            });
        }
    }
}