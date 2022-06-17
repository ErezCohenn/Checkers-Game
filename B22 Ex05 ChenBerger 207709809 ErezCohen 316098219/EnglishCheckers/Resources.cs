using System.IO;
namespace EnglishCheckersWinUI
{
    public class Resources
    {
        private static readonly string sr_RedPawnImage = "RedPawn.png";
        private static readonly string sr_RedKingImage = "‏‏RedKing.png";
        private static readonly string sr_BlackPawnImage = "‏‏BlackPawn.png";
        private static readonly string sr_BlackKingImage = "‏‏BlackKing.png";
        private static readonly string sr_‏‏DisabledCellImage = "‏‏DisabledCell.png";
        private static readonly string sr_EmptyCellImage = "EmptyCell.png";
        private static readonly string sr_ResourcesFolderPath;

        static Resources()
        {
            sr_ResourcesFolderPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Resources");
        }

        public static string RedPawn
        {
            get
            {
                return sr_RedPawnImage;
            }
        }

        public static string RedKingPawn
        {
            get
            {
                return sr_RedKingImage;
            }
        }

        public static string BlackPawn
        {
            get
            {
                return sr_BlackPawnImage;
            }
        }

        public static string BlackKingPawn
        {
            get
            {
                return sr_BlackKingImage;
            }
        }

        public static string Disabled
        {
            get
            {
                return sr_‏‏DisabledCellImage;
            }
        }

        public static string Empty
        {
            get
            {
                return sr_EmptyCellImage;
            }
        }

        public static string ResourcesFolderPath
        {
            get
            {
                return sr_ResourcesFolderPath;
            }
        }
    }
}
