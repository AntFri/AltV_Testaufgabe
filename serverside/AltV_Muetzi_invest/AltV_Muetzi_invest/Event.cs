using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AltV_Muetzi_invest
{
    public class Event : IScript
    {
        // Defining two Arrays for the colShapes used for the  damage arrea and Shooting arrea, maximum of 10 ColShapes.
        List<IColShape> dmColShape = new List<IColShape> ();
        List<IColShape> sttColShape = new List<IColShape>();


        // Player Connect event used to define the player Ped Model  and spawn point as well as logging which player joined the server
        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public void OnPlayerConenct(IPlayer player, String reason)
        {
            player.Spawn(new AltV.Net.Data.Position(-427, 1115, 326),0);
            player.Model = (uint)PedModel.Eastsa02AFM;
            Alt.Log($"{player.Name} Ist dem server beigetreten!");
        }


        // PLayer Damage event is used to know when a player gets damage, thsi cna be also fall damage.
        [ScriptEvent(ScriptEventType.PlayerDamage)]
        public void OnPlayerDamage(IPlayer player, IEntity attacker, uint weapon, ushort healthDamage, ushort armourDamage)
        {
            Alt.Log($"{player.Name} Hat schaden erlitten von:  {weapon.ToString()}");
            // Add a new colShape to the Damage List after the palyer got damage
            dmColShape.Add(Alt.CreateColShapeCircle(player.Position, 1.0f));
            
        }


        // Player Weapon Damage used to know which player shoot and who got hit.
        [ScriptEvent(ScriptEventType.WeaponDamage)]
        public  void OnPlayerWeaponDm(IPlayer player, IEntity target, uint weapon, ushort damage, Position offset, BodyPart bodyPart)
        {
            Alt.Log($"{player.Name} hat den gegner: {target} mit:  {weapon} und mit einer schaden von: {damage} mit dem offset: {offset} attackiert!");
            // Add a new colShape to the Damage List after the palyer got shot by someone
            dmColShape.Add(Alt.CreateColShapeCircle(target.Position, 1.0f));
        }


        // Event to check if someone is in the colShape  and which Entity
        [ScriptEvent(ScriptEventType.ColShape)]
        public void OnEntityColshape(IColShape shape, IEntity entity, bool state)
        {
            // Tranformes the Boolean State into a String of the Message to the player.
            String status = state ? "Breteten" : "verlassen";

            switch (entity)
            {
                case IPlayer iplayer:
                    // Check if a player is in a shape that is a Damage ColShape
                    if (dmColShape.Contains(shape))
                    {
                        // Send Message to player, could also Launch Client event
                        iplayer.SendChatMessage($"{status} vom Damage colShape {shape.Id}");
                        iplayer.Emit("InBlutColShape", state, shape.Id);
                    }

                    if (sttColShape.Contains(shape))
                    {
                        // Send Message to player, Could also Launch Client event.
                        iplayer.SendChatMessage($"{status} vom schuss colShape {shape.Id}");
                        iplayer.Emit("InHuelsenColShape", state, shape.Id);
                    }
                break;
            }
        }



        // Client side event to Add a ColShape to the Shoot List,
        [ClientEvent("PLAYER_SHOOT_EVENT")]
        public void OnPlayerIsShoot(IPlayer player, uint weapon, ushort totalAmmo, ushort ammoInClip) 
        {
            // Logs the Shot form who it came, which weapon and total ammo as well as AmmoInClip (magazine)
            Alt.Log($"{player.Name} hat mit:  {weapon} es sind somit noch: {totalAmmo} schuss in der waffe und: {ammoInClip} Im Magazine!");
            // Add to the List when a player shoot
            sttColShape.Add(Alt.CreateColShapeCircle(player.Position, 1.0f));
            
        }

        
    }
}
