﻿using Farazpardazan.Media.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Farazpardazan.Media.Authorization
{
    public class MediaPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var moduleGroup = context.AddGroup(MediaPermissions.GroupName, L("Permission:Media"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MediaResource>(name);
        }
    }
}