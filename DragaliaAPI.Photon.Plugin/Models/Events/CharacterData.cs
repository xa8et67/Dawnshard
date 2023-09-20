﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using MessagePack;
using DragaliaAPI.Photon.Shared.Models;

namespace DragaliaAPI.Photon.Plugin.Models.Events
{
    [MessagePackObject(false)]
    public class CharacterData : EventBase<CharacterData>
    {
        [Key(1)]
        public int playerId { get; set; }

        [Key(2)]
        public HeroParam[] heroParams { get; set; }

        [Key(3)]
        public HeroParam[] unusedHeroParams { get; set; }

        [Key(4)]
        public HeroParamExData[] heroParamExs { get; set; }
    }
}