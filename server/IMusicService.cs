using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace server
{
    [ServiceContract]
    public interface IMusicService
    {
        [OperationContract]
        List<song_view> GetSongViews();

        //下载文件
        [OperationContract]
        DownFileResult DownLoadFile(DownFile downfile);
    }

    [MessageContract]
    public class DownFile
    {
        [MessageHeader]
        public int Id { get; set; }
    }

    [MessageContract]
    public class DownFileResult
    {
        [MessageHeader]
        public long FileSize { get; set; }
        [MessageHeader]
        public bool IsSuccess { get; set; }
        [MessageBodyMember]
        public Byte[] FileBytes { get; set; }
    }
}
