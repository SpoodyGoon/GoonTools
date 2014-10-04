using System;

namespace BookmarkSharp.DataModel
{
    public static class Utility
    {
        public static ModelStatus ModelStatusParse(string statusName)
        {
            ModelStatus outModelStatus;
            ModelStatus returnStatus = ModelStatus.None;
            if (Enum.TryParse<ModelStatus>(statusName, out outModelStatus))
            {
                returnStatus = outModelStatus;
            }
            return returnStatus;
        }
    }
}