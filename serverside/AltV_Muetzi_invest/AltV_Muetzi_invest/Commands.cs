using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AltV_Muetzi_invest
{
    internal class Commands : IScript
    {
        [CommandEvent(CommandEventType.CommandNotFound)]
        public void OnCommandNotFound(IPlayer iplayer, string command)
        {
            iplayer.SendChatMessage($"Befehl {command} nicht gefunden");
            return;
        }

        [Command("wp")]
        public void Cmd_wp(IPlayer iplayer, string weaponName, int ammunition = 90)
        {
            AltV.Net.Enums.WeaponModel wp;
            switch (weaponName)
            {
                case "AssaultRifle":
                    wp = AltV.Net.Enums.WeaponModel.AssaultRifle;
                    break;
                case "Pistol":
                    wp = AltV.Net.Enums.WeaponModel.Pistol;
                    break;
                default:
                    wp = AltV.Net.Enums.WeaponModel.StickyBomb;
                    break;
            }
            iplayer.GiveWeapon(wp, ammunition, true);
        }
    }
}
