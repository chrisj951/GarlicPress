﻿
using GarlicPress.classes.bitmapClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using static System.Net.WebRequestMethods;

namespace GarlicPress
{
    public enum SearchType
    {
        GameName,
        GameID
    }

    public class GarlicGameArtSearch
    {
        public GarlicSystem system { get; set; }
        public GarlicDrive drive { get; set; }
        public SearchType searchType { get; set; }
        public string status { get; set; }
        public string searchText { get; set; }
        public string fileName { get; set; }
        public string systemName { get { return system.name; } }
        public string driveName { get { return drive.name; } }
        public string filePath { get { return drive.romPath + "/" + system.folder + "/" + fileName; } }
        public string imgPath { get { return drive.path + "/Roms/" + system.folder + "/Imgs/" + Path.ChangeExtension(fileName, ".png"); } }

        public GarlicGameArtSearch(GarlicSystem system, GarlicDrive drive, SearchType searchType, string fileName)
        {
            this.system = system;
            this.drive = drive;
            this.searchType = searchType;
            this.fileName = fileName;
            status = "";
            searchText = fileName;
        }
    }

    public class GarlicSystem
    {
        public string name { get; set; }
        public string folder { get; set; }
        public List<string> extensions { get; set; }
        public string ss_systemeid { get; set; }  //
        public string ss_romtype { get; set; }
        public GarlicSystem(string name, string folder, string ss_systemeid, string ss_romtype, List<string> extensions)
        {
            this.name = name;
            this.folder = folder;
            this.extensions = extensions;
            this.ss_systemeid = ss_systemeid;
            this.ss_romtype = ss_romtype;
        }


        public static List<GarlicSystem> GetAllSystems()
        {
            List<GarlicSystem> systems = new List<GarlicSystem>()
        { //https://github.com/OnionUI/Onion/wiki/Emulators#rom-folders---quick-reference
            new GarlicSystem("Amiga",  "AMIGA", "64", "rom", new List<string>(){}),
            new GarlicSystem("Amstrad CPC",  "CPC", "65", "rom", new List<string>(){}),

            new GarlicSystem("Arcade (Mame 2003+)",  "ARCADE", "75", "rom", new List<string>(){}),
            new GarlicSystem("Arcade (FinalBurn 2012)",  "FBA2012", "75", "rom", new List<string>(){}),
            new GarlicSystem("Arcade (FinalBurn Neo)",  "FBNEO", "75", "rom", new List<string>(){}),
            new GarlicSystem("Arcade (Mame 2000)",  "MAME2000", "75", "rom", new List<string>(){}),

            new GarlicSystem("Atari 2600", "ATARI", "26", "rom", new List<string>(){}),
            new GarlicSystem("Atari 5200", "FIFTYTWOHUNDRED", "40", "rom", new List<string>(){}),
            new GarlicSystem("Atari 7800", "SEVENTYEIGHTHUNDRED", "41", "rom", new List<string>(){}),
            new GarlicSystem("Atari Lynx", "LYNX", "28", "rom", new List<string>(){}),
            new GarlicSystem("Bandai Sufami Turbo", "SUFAMI", "108", "rom", new List<string>(){}),
            new GarlicSystem("Bandai WonderSwan & Color", "WS", "45", "rom", new List<string>(){}),
            new GarlicSystem("Capcom Play System 1", "CPS1", "75", "rom", new List<string>(){}),
            new GarlicSystem("Capcom Play System 2", "CPS2", "75", "rom", new List<string>(){}),
            new GarlicSystem("Capcom Play System 3", "CPS3", "75", "rom", new List<string>(){}),
            new GarlicSystem("ColecoVision", "COLECO", "48", "rom", new List<string>(){}),
            new GarlicSystem("Fairchild Channel F", "FAIRCHILD", "80", "rom", new List<string>(){}),
            new GarlicSystem("Famicom Disk System", "FDS", "106", "rom", new List<string>(){}),
            new GarlicSystem("Game & Watch", "GW", "52", "rom", new List<string>(){}),
            new GarlicSystem("GCE Vectrex", "VECTREX", "102", "rom", new List<string>(){}),
            new GarlicSystem("Magnavox Odyssey 2", "ODYSSEY", "104", "rom", new List<string>(){}),
            new GarlicSystem("Mattel Intellivision", "INTELLIVISION", "115", "rom", new List<string>(){}),
            new GarlicSystem("Mega Duck", "MEGADUCK", "90", "rom", new List<string>(){}),
            new GarlicSystem("MS-DOS", "DOS", "135", "dossier", new List<string>(){}),
            new GarlicSystem("MSX - MSX2", "MSX", "113", "rom", new List<string>(){}),
            new GarlicSystem("PC Engine SuperGrafx", "SGFX", "105", "rom", new List<string>(){}),
            new GarlicSystem("PC Engine CD-Rom", "PCECD", "114", "rom", new List<string>(){}),
            new GarlicSystem("PC Engine", "PCE", "31", "rom", new List<string>(){}),
            new GarlicSystem("Nintendo Entertainment System", "FC", "3", "rom", new List<string>(){}),
            new GarlicSystem("Nintendo Pokemini", "POKE", "211", "rom", new List<string>(){}),
            new GarlicSystem("Nintendo Satellaview", "SATELLAVIEW", "107", "rom", new List<string>(){}),
            new GarlicSystem("Nintendo Super Game Boy", "SGB", "127", "rom", new List<string>(){}),
            new GarlicSystem("Nintendo Super Nintendo", "SFC", "4", "rom", new List<string>(){}),
            new GarlicSystem("Nintendo Virtual Boy", "VB", "11", "rom", new List<string>(){}),
            new GarlicSystem("Nintendo Game Boy", "GB", "9", "rom", new List<string>(){".gb", ".gbc", ".dmg", ".zip", ".7z"}),
            new GarlicSystem("Nintendo Game Boy Color", "GBC", "10", "rom", new List<string>(){".gb", ".gbc", ".dmg", ".zip", ".7z"}),
            new GarlicSystem("Nintendo Game Boy Advance", "GBA", "12", "rom", new List<string>(){".gb", ".gbc", ".dmg", ".zip", ".7z"}),
            new GarlicSystem("Nintendo DS", "NDS", "15", "rom", new List<string>(){".nds"}),
            new GarlicSystem("Sony Playstation", "PS", "57", "iso", new List<string>(){".chd"}),
            new GarlicSystem("PICO-8", "PICO", "234", "fichier", new List<string>(){}),
            new GarlicSystem("Ports collection", "PORTS", "?", "fichier", new List<string>(){}),
            new GarlicSystem("ScummVM", "SCUMMVM", "123", "dossier", new List<string>(){}),
            new GarlicSystem("Sega 32X", "THIRTYTWOX", "19", "rom", new List<string>(){}),
            new GarlicSystem("Sega CD", "SEGACD", "20", "iso", new List<string>(){}),
            new GarlicSystem("Sega Game Gear", "GG", "21", "rom", new List<string>(){}),
            new GarlicSystem("Sega Genesis", "MD", "1", "rom", new List<string>(){}),
            new GarlicSystem("Sega Master System", "MS", "2", "rom", new List<string>(){}),
            new GarlicSystem("Sega SG-1000", "SEGASGONE", "109", "rom", new List<string>(){}),
            new GarlicSystem("Sinclair ZX Spectrum", "ZXS", "76", "rom", new List<string>(){}),
            new GarlicSystem("SNK NeoGeo", "NEOGEO", "75", "rom", new List<string>(){}),
            new GarlicSystem("SNK NeoGeo CD", "NEOCD", "70", "iso", new List<string>(){}),
            new GarlicSystem("SNK NeoGeo Pocket & Color", "NGP", "82", "rom", new List<string>(){}),
            new GarlicSystem("TIC-80", "TIC", "222", "rom", new List<string>(){}),
            new GarlicSystem("VideoPac", "VIDEOPAC", "104", "rom", new List<string>(){}),
            new GarlicSystem("Watara Supervision", "SUPERVISION", "207", "rom", new List<string>(){}),
            new GarlicSystem("Commodore 64", "COMMODORE", "66", "rom", new List<string>(){}),
        };

            return systems.OrderBy(o => o.name).ToList();
        }
    }

    public class GarlicDrive
    {
        public string name { get; set; }
        public string path { get; set; }
        public int number { get; set; }
        public string romPath { get { return number == 2 && Properties.Settings.Default.romsOnRootSD2 ? path + "/" : path + "/Roms"; } }

        public GarlicDrive(string name, string path, int number)
        {
            this.name = name;
            this.path = path;
            this.number = number;
        }

        public static List<GarlicDrive> GetGarlicDrives()
        {
            List<GarlicDrive> drives = new List<GarlicDrive>()
        {
            new GarlicDrive("SD Card 1",  "/mnt/mmc", 1),
            new GarlicDrive("SD Card 2",  "/mnt/SDCARD", 2),
        };
            return drives;
        }
    }

    public class GarlicLanguageSettingsFile
    {
        public string fileKey { get; set; }
        public string fileName { get; set; }
        public GarlicLanguageSettings garlicLanguageSettings { get; set; }

        public GarlicLanguageSettingsFile(string fileName, GarlicLanguageSettings garlicLanguageSettings)
        {
            this.fileName = fileName;
            this.fileKey = fileName.ToLower();
            this.garlicLanguageSettings = garlicLanguageSettings;
        }
    }

#nullable disable

    public class GarlicLanguageSettings
    {
        [JsonPropertyName("iso-code")] public string isocode { get; set; }
        public string font { get; set; }
        [JsonPropertyName("font-size")] public int fontsize { get; set; }
        [JsonPropertyName("button-guide-font-size")] public int buttonguidefontsize { get; set; }
        [JsonPropertyName("recent-label")] public string recentlabel { get; set; }
        [JsonPropertyName("favorites-label")] public string favoriteslabel { get; set; }
        [JsonPropertyName("consoles-label")] public string consoleslabel { get; set; }
        [JsonPropertyName("retroarch-label")] public string retroarchlabel { get; set; }
        [JsonPropertyName("settings-label")] public string settingslabel { get; set; }
        [JsonPropertyName("language-label")] public string languagelabel { get; set; }
        [JsonPropertyName("navigate-label")] public string navigatelabel { get; set; }
        [JsonPropertyName("open-label")] public string openlabel { get; set; }
        [JsonPropertyName("back-label")] public string backlabel { get; set; }
        [JsonPropertyName("favorite-label")] public string favoritelabel { get; set; }
        [JsonPropertyName("remove-label")] public string removelabel { get; set; }
        [JsonPropertyName("empty-label")] public string emptylabel { get; set; }
        [JsonPropertyName("savestates-unsupported")] public string savestatesunsupported { get; set; }
        [JsonPropertyName("on-label")] public string onlabel { get; set; }
        [JsonPropertyName("off-label")] public string offlabel { get; set; }
        [JsonPropertyName("am-label")] public string amlabel { get; set; }
        [JsonPropertyName("pm-label")] public string pmlabel { get; set; }
        [JsonPropertyName("year-label")] public string yearlabel { get; set; }
        [JsonPropertyName("month-label")] public string monthlabel { get; set; }
        [JsonPropertyName("day-label")] public string daylabel { get; set; }
        [JsonPropertyName("hour-label")] public string hourlabel { get; set; }
        [JsonPropertyName("minute-label")] public string minutelabel { get; set; }
        [JsonPropertyName("meridian-time-label")] public string meridiantimelabel { get; set; }
        [JsonPropertyName("title-label")] public string titlelabel { get; set; }
    }

    public class GarlicSkinSettings
    {
        [JsonPropertyName("text-alignment")] public string textalignment { get; set; }
        [JsonPropertyName("text-margin")] public int textmargin { get; set; }
        [JsonPropertyName("color-guide")] public string colorguide { get; set; }
        [JsonPropertyName("color-inactive")] public string colorinactive { get; set; }
        [JsonPropertyName("color-active")] public string coloractive { get; set; }
        [JsonPropertyName("color-favorite-inactive")] public string colorfavoriteinactive { get; set; }
        [JsonPropertyName("color-favorite-active")] public string colorfavoriteactive { get; set; }
        [JsonPropertyName("main-menu-text-visibility")] public bool mainmenutextvisibility { get; set; }
        [JsonPropertyName("guide-button-text-visibility")] public bool guidebuttontextvisibility { get; set; }
        [JsonPropertyName("recent-label")] public string recentlabel { get; set; }
        [JsonPropertyName("favorites-label")] public string favoriteslabel { get; set; }
        [JsonPropertyName("consoles-label")] public string consoleslabel { get; set; }
        [JsonPropertyName("retroarch-label")] public string retroarchlabel { get; set; }
        [JsonPropertyName("rtc-label")] public string rtclabel { get; set; }
        [JsonPropertyName("navigate-label")] public string navigatelabel { get; set; }
        [JsonPropertyName("open-label")] public string openlabel { get; set; }
        [JsonPropertyName("back-label")] public string backlabel { get; set; }
        [JsonPropertyName("favorite-label")] public string favoritelabel { get; set; }
        [JsonPropertyName("remove-label")] public string removelabel { get; set; }
        [JsonPropertyName("empty-label")] public string emptylabel { get; set; }
        [JsonPropertyName("savestates-unsupported")] public string savestatesunsupported { get; set; }
        [JsonPropertyName("on-label")] public string onlabel { get; set; }
        [JsonPropertyName("off-label")] public string offlabel { get; set; }
        [JsonPropertyName("am-label")] public string amlabel { get; set; }
        [JsonPropertyName("pm-label")] public string pmlabel { get; set; }
        [JsonPropertyName("year-label")] public string yearlabel { get; set; }
        [JsonPropertyName("month-label")] public string monthlabel { get; set; }
        [JsonPropertyName("day-label")] public string daylabel { get; set; }
        [JsonPropertyName("hour-label")] public string hourlabel { get; set; }
        [JsonPropertyName("minute-label")] public string minutelabel { get; set; }
        [JsonPropertyName("meridian-time-label")] public string meridiantimelabel { get; set; }
        [JsonPropertyName("title-label")] public string titlelabel { get; set; }
    }

    public class SSMediaType
    {
        public string label { get; set; }
        public string value { get; set; }
        public MediaTypes mediaType { get; set; }

        public SSMediaType(string label, string value, MediaTypes mediaType)
        {
            this.label = label;
            this.value = value;
            this.mediaType = mediaType;
        }

        public static List<SSMediaType> GetAllMediaTypes()
        {
            List<SSMediaType> systems = new List<SSMediaType>()
        {
            new SSMediaType("Logo", "wheel", MediaTypes.SSGame),
            new SSMediaType("Logo Steel", "wheel-steel", MediaTypes.SSGame),
            new SSMediaType("Logo Carbon", "wheel-carbon", MediaTypes.SSGame),
            new SSMediaType("Logo Steam Grid", "steamgrid", MediaTypes.SSGame),
            new SSMediaType("Screen Marquee", "screenmarquee", MediaTypes.SSGame),
            new SSMediaType("Screen Marquee Small", "screenmarqueesmall", MediaTypes.SSGame),
            new SSMediaType("3D Box", "box-3D", MediaTypes.SSGame),
            new SSMediaType("2D Box", "box-2D", MediaTypes.SSGame),
            new SSMediaType("2D Support", "support-2D", MediaTypes.SSGame),
            new SSMediaType("Screen Shot", "ss", MediaTypes.SSGame),
            new SSMediaType("Screen Shot Title", "sstitle", MediaTypes.SSGame),
            new SSMediaType("Fan Art", "fanart", MediaTypes.SSGame),
            new SSMediaType("Mixed Image v1", "mixrbv1", MediaTypes.SSGame),
            new SSMediaType("Mixed Image v2", "mixrbv2", MediaTypes.SSGame),
            new SSMediaType("Developer Logo", "pictomonochrome", MediaTypes.SSGame),
            new SSMediaType("Developer Logo Color", "pictocouleur", MediaTypes.SSGame),
            new SSMediaType("Local Media", "local", MediaTypes.Local),
            new SSMediaType("System Logo Monochrome", "system-logo-monochrome", MediaTypes.SSSystem),
            new SSMediaType("System Logo", "system-wheel", MediaTypes.SSSystem),
            new SSMediaType("System Logo Steel", "system-wheel-steel", MediaTypes.SSSystem),
            new SSMediaType("System Logo Carbon", "system-wheel-carbon", MediaTypes.SSSystem),
            new SSMediaType("System Icon Mini", "system-minicon", MediaTypes.SSSystem),
            new SSMediaType("System Icon", "system-icon", MediaTypes.SSSystem),
            new SSMediaType("System Picture", "system-photo", MediaTypes.SSSystem),
            new SSMediaType("System Illustration", "system-illustration", MediaTypes.SSSystem),
            new SSMediaType("System Steam Grid", "system-steam-grid", MediaTypes.SSSystem),
            new SSMediaType("System Bezel 4:3", "system-bezel-4-3", MediaTypes.SSSystem),
            new SSMediaType("System Bezel 16:9", "system-bezel-16-9", MediaTypes.SSSystem),
            new SSMediaType("System Bezel 16:9 Vertical", "system-bezel-16-9v", MediaTypes.SSSystem),
            new SSMediaType("System Support 2D", "system-support2D", MediaTypes.SSSystem),
            new SSMediaType("System Box Blank", "system-box-tranche-vierge", MediaTypes.SSSystem)
        };

            return systems;
        }

        public enum MediaTypes
        {
            SSGame = 0,
            SSSystem = 1,
            Local = 2
        }
    }

    public class MediaLayerCollection
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string name { get; set; } = "New Collection";
        public bool defaultCollection { get; set; }
        public List<MediaLayer> mediaLayers { get; set; } = new List<MediaLayer>();
    }

    public class MediaLayer
    {
        public string mediaType { get; set; }
        public double resizePercent { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int order { get; set; }
        public Guid id { get; set; }
        public int angle { get; set; }
        public string region { get; set; }
        public string path { get; set; }
        public List<IFilter> Filters { get; set; }

        public MediaLayer Clone()
        {
            if (MemberwiseClone() is MediaLayer clone)
            {
                clone.id = Guid.NewGuid();
                clone.Filters = new List<IFilter>();
                foreach (var filter in Filters)
                {
                    clone.Filters.Add(filter.Clone());
                }
                return clone;
            }
            return new MediaLayer();
        }

        public MediaLayer()
        {
            mediaType = "wheel";
            width = 0;
            height = 0;
            resizePercent = 100;
            x = 0;
            y = 0;
            order = 0;
            id = Guid.NewGuid();
            angle = 0;
            region = "us";
            Filters = new List<IFilter>();
        }

    }

    public struct MediaResponse
    {
        public string path { get; set; }
        public string region { get; set; }

        public MediaResponse(string path, string region)
        {
            this.path = path;
            this.region = region;
        }
    }

    public class SkinMedia
    {
        public string MediaFileName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Text { get; set; }
        public SkinMediaTypes SkinMediaType { get; set; }

        public enum SkinMediaTypes
        {
            Picture = 0,
            Text = 1,
            Clock = 2,
            SystemName = 3,
            NavigateLabel = 4,
            OpenLabel = 5,
            BackLabel = 6,
            FavoriteLabel = 7
        }

        private static List<SkinMedia> _defaultSkinMedias = null;

        public static List<SkinMedia> GetSkinMedias()
        {
            if (_defaultSkinMedias == null)
            {
                _defaultSkinMedias = new List<SkinMedia>()
        {
            new SkinMedia() { MediaFileName = "icon-dpad-54.png", X = 5, Y = 420, Text = "", SkinMediaType = SkinMediaTypes.Picture },
            new SkinMedia() { MediaFileName = "", X = 55, Y = 427, Text = "NAVIGATE", SkinMediaType = SkinMediaTypes.NavigateLabel },

            new SkinMedia() { MediaFileName = "icon-A-54.png", X = 195, Y = 420, Text = "", SkinMediaType = SkinMediaTypes.Picture },
            new SkinMedia() { MediaFileName = "", X = 245, Y = 427, Text = "OPEN", SkinMediaType = SkinMediaTypes.OpenLabel },

            new SkinMedia() { MediaFileName = "icon-B-54.png", X = 325, Y = 420, Text = "", SkinMediaType = SkinMediaTypes.Picture },
            new SkinMedia() { MediaFileName = "", X = 375, Y = 427, Text = "BACK", SkinMediaType = SkinMediaTypes.BackLabel },

            new SkinMedia() { MediaFileName = "icon-Y-54.png", X = 450, Y = 420, Text = "", SkinMediaType = SkinMediaTypes.Picture },
            new SkinMedia() { MediaFileName = "", X = 500, Y = 427, Text = "FAVORITE", SkinMediaType = SkinMediaTypes.FavoriteLabel },

            new SkinMedia() { MediaFileName = "logo.png", X = 15, Y = 8, Text = "", SkinMediaType = SkinMediaTypes.Picture },
            new SkinMedia() { MediaFileName = "", X = 57, Y = 10, Text = "", SkinMediaType = SkinMediaTypes.SystemName },

            new SkinMedia() { MediaFileName = "charging-05.png", X = 580, Y = 5, Text = "", SkinMediaType = SkinMediaTypes.Picture },
            new SkinMedia() { MediaFileName = "", X = 490, Y = 10, Text = "", SkinMediaType = SkinMediaTypes.Clock },
        };
            }
            return _defaultSkinMedias;
        }
    }

    public class GameResponse
    {

        public Header header { get; set; }
        public Response response { get; set; }
        public string status { get; set; }
        public string statusMessage { get; set; }

        public class Response
        {
            public Serveurs serveurs { get; set; }
            public Ssuser ssuser { get; set; }
            public Jeu jeu { get; set; }
        }

        public class Jeu
        {
            public string id { get; set; }
            public string romid { get; set; }
            public string notgame { get; set; }
            public Nom[] noms { get; set; }
            public string cloneof { get; set; }
            public Systeme systeme { get; set; }
            public Editeur editeur { get; set; }
            public Developpeur developpeur { get; set; }
            public Joueurs joueurs { get; set; }
            public Note note { get; set; }
            public string topstaff { get; set; }
            public string rotation { get; set; }
            public string resolution { get; set; }
            public Synopsis[] synopsis { get; set; }
            public Date[] dates { get; set; }
            public Genre[] genres { get; set; }
            public Famille[] familles { get; set; }
            public Couleur[] couleurs { get; set; }
            public Action[] actions { get; set; }
            public Media[] medias { get; set; }
            public Rom[] roms { get; set; }
            public Rom rom { get; set; }
        }

        public class Systeme
        {
            public string id { get; set; }
            public string text { get; set; }
            public string parentid { get; set; }
        }

        public class Editeur
        {
            public string id { get; set; }
            public string text { get; set; }
        }

        public class Developpeur
        {
            public string id { get; set; }
            public string text { get; set; }
        }

        public class Joueurs
        {
            public string text { get; set; }
        }

        public class Note
        {
            public string text { get; set; }
        }

        public class Rom
        {
            public string id { get; set; }
            public string romfilename { get; set; }
            public string romregions { get; set; }
            public string romtype { get; set; }
            public string romsupporttype { get; set; }
            public string romsize { get; set; }
            public string romcrc { get; set; }
            public string rommd5 { get; set; }
            public string romsha1 { get; set; }
            public string romcloneof { get; set; }
            public string beta { get; set; }
            public string demo { get; set; }
            public string proto { get; set; }
            public string trad { get; set; }
            public string hack { get; set; }
            public string unl { get; set; }
            public string alt { get; set; }
            public string best { get; set; }
            public string netplay { get; set; }
            public Clonetypes clonetypes { get; set; }
            public Regions regions { get; set; }
        }

        public class Clonetypes
        {
            public string[] clonetypes_id { get; set; }
            public string[] clonetypes_fr { get; set; }
        }

        public class Regions
        {
            public string[] regions_id { get; set; }
            public string[] regions_shortname { get; set; }
            public string[] regions_en { get; set; }
            public string[] regions_fr { get; set; }
            public string[] regions_de { get; set; }
            public string[] regions_es { get; set; }
            public string[] regions_pt { get; set; }
        }

        public class Nom
        {
            public string langue { get; set; }
            public string region { get; set; }
            public string text { get; set; }
        }

        public class Synopsis
        {
            public string langue { get; set; }
            public string text { get; set; }
        }

        public class Date
        {
            public string region { get; set; }
            public string text { get; set; }
        }

        public class Genre
        {
            public string id { get; set; }
            public string nomcourt { get; set; }
            public string principale { get; set; }
            public string parentid { get; set; }
            public Nom[] noms { get; set; }
        }



        public class Famille
        {
            public string id { get; set; }
            public string nomcourt { get; set; }
            public string principale { get; set; }
            public string parentid { get; set; }
            public Nom[] noms { get; set; }
        }



        public class Couleur
        {
            public string id { get; set; }
            public string controle { get; set; }
            public string hexa { get; set; }
        }

        public class Action
        {
            public string id { get; set; }
            public Controle[] controle { get; set; }
        }

        public class Controle
        {
            public string langue { get; set; }
            public string text { get; set; }
            public string recalboxtext { get; set; }
        }
    }

    public class SystemsResponse
    {
        public Header header { get; set; }
        public Response response { get; set; }
        public string status { get; internal set; }
        public string statusMessage { get; internal set; }

        public class Response
        {
            public Serveurs serveurs { get; set; }
            public Ssuser ssuser { get; set; }
            public Systeme[] systemes { get; set; }
        }

        public class Systeme
        {
            public int id { get; set; }
            public Noms noms { get; set; }
            public string extensions { get; set; }
            public string compagnie { get; set; }
            public string type { get; set; }
            public string datedebut { get; set; }
            public string datefin { get; set; }
            public string romtype { get; set; }
            public string supporttype { get; set; }
            public Media[] medias { get; set; }
            public int parentid { get; set; }
        }

        public class Noms
        {
            public string nom_eu { get; set; }
            public string nom_us { get; set; }
            public string nom_recalbox { get; set; }
            public string nom_retropie { get; set; }
            public string nom_launchbox { get; set; }
            public string nom_hyperspin { get; set; }
            public string noms_commun { get; set; }
            public string nom_jp { get; set; }
        }
    }

    public class Header
    {
        public string APIversion { get; set; }
        public string dateTime { get; set; }
        public string commandRequested { get; set; }
        public string success { get; set; }
        public string error { get; set; }
    }

    public class Serveurs
    {
        public string cpu1 { get; set; }
        public string cpu2 { get; set; }
        public string cpu3 { get; set; }
        public string threadsmin { get; set; }
        public string nbscrapeurs { get; set; }
        public string apiacces { get; set; }
        public string closefornomember { get; set; }
        public string closeforleecher { get; set; }
        public string maxthreadfornonmember { get; set; }
        public string threadfornonmember { get; set; }
        public string maxthreadformember { get; set; }
        public string threadformember { get; set; }
    }

    public class Ssuser
    {
        public string id { get; set; }
        public string numid { get; set; }
        public string niveau { get; set; }
        public string contribution { get; set; }
        public string uploadsysteme { get; set; }
        public string uploadinfos { get; set; }
        public string romasso { get; set; }
        public string uploadmedia { get; set; }
        public string propositionok { get; set; }
        public string propositionko { get; set; }
        public string quotarefu { get; set; }
        public string maxthreads { get; set; }
        public string maxdownloadspeed { get; set; }
        public string requeststoday { get; set; }
        public string requestskotoday { get; set; }
        public string maxrequestspermin { get; set; }
        public string maxrequestsperday { get; set; }
        public string maxrequestskoperday { get; set; }
        public string visites { get; set; }
        public string datedernierevisite { get; set; }
        public string favregion { get; set; }
    }

    public class Media
    {
        public string type { get; set; }
        public string parent { get; set; }
        public string url { get; set; }
        public string region { get; set; }
        public string crc { get; set; }
        public string md5 { get; set; }
        public string sha1 { get; set; }
        public string size { get; set; }
        public string format { get; set; }
        public string posx { get; set; }
        public string posy { get; set; }
        public string posw { get; set; }
        public string posh { get; set; }
        public string id { get; set; }
        public string subparent { get; set; }

        public string support { get; set; }
    }
}
#nullable enable
