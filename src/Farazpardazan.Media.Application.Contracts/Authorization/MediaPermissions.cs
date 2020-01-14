using Volo.Abp.Reflection;

namespace Farazpardazan.Media.Authorization
{
    public class MediaPermissions
    {
        public const string GroupName = "Media";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(MediaPermissions));
        }
    }
}