using AltV.Net.Elements.Entities;
using AltV.Net.Interactions;
using AltV_Muetzi_invest.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AltV_Muetzi_invest
{
    public class HuelseInteraction : Interaction
    {

        public HuelseEntity Huelse { get; }
        public HuelseInteraction(HuelseEntity huelse, ulong type, ulong id, Vector3 position, int dimension, uint range) : base(type, id, position, dimension, range)
        {
            this.Huelse = huelse;
        }

        public static bool OnInteraction(IPlayer player, Vector3 interactionPosition, int interactionDimension)
        {
            // do something with the House obj
            return false;
        }
    }
}
