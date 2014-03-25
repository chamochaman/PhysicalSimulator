using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicalSimulator
{
    class Entity : Object
    {
        private string tag;
        private bool activeInScene;
        private Animation animation;
        private Collider collider;
        private int layer;

        public void SetActive(bool state)
        {
            this.activeInScene = state;
        }

        public bool CompareTag(string tag)
        {
            if(this.tag == tag)
                return true;
            return false;
        }
    }
}
