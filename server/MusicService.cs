using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace server
{
    public class MusicService : IMusicService
    {
        public DownFileResult DownLoadFile(DownFile downfile)
        {
            using(playerdbEntities context = new playerdbEntities())
            {
                var query = (from s in context.songs
                             where s.id == downfile.Id
                             select new { s.file,s.file_length}).FirstOrDefault();
                if (query != null)
                {
                    return new DownFileResult()
                    {
                        FileSize = query.file_length,
                        FileBytes = query.file,
                        IsSuccess = true
                    };
                }
                else
                {
                    return new DownFileResult()
                    {
                        FileBytes = null,
                        FileSize = 0,
                        IsSuccess = false
                    };
                }
            }
            
        }

        public List<song_view> GetSongViews()
        {
            using(playerdbEntities context = new playerdbEntities())
            {
                List<song_view> songViews = new List<song_view>();
                var query = from sv in context.song_view
                            select sv;
                foreach (var sv in query)
                {
                    songViews.Add(sv);
                }
                return songViews;
            }
        }
    }
}
