using System.Web;

namespace Business.IBusiness
{
    public interface IFileBusiness
    {
        string UploadFile(HttpPostedFileBase PostedFile);
    }
}
