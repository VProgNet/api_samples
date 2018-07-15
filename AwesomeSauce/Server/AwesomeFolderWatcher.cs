using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeSauce.Server
{
    public class AwesomeFolderWatcher<TContext>
    {
        private readonly FileSystemWatcher _watcher;
        private readonly IHttpApplication<TContext> _application;
        private readonly IFeatureCollection _features;
        public AwesomeFolderWatcher(IHttpApplication<TContext> application, 
                                    IFeatureCollection features)
        {
            var path = features.Get<IServerAddressesFeature>().Addresses.FirstOrDefault();
            _watcher = new FileSystemWatcher(path);
            _watcher.EnableRaisingEvents = true;
            _application = application;
            _features = features;
        }


        public void Watch()
        {
            _watcher.Created += OnChangeFile;
            Task.Run(() => _watcher.WaitForChanged(WatcherChangeTypes.All));
        }

        private async void OnChangeFile(object sender, FileSystemEventArgs e)
        {
            var context = (HostingApplication.Context)(object)_application.CreateContext(_features);
            context.HttpContext = new AwesomeHttpContext(_features, e.FullPath);
            await _application.ProcessRequestAsync((TContext)(object)context);
            context.HttpContext.Response.OnCompleted(null, null);

        }
    }
}