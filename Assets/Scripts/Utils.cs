using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Utils
{
    public static class Constants
    {
        public static readonly float BOTTOM_MARGIN      = -2.37f;
        public static readonly float UPPER_MARGIN       = 0f;
        public static readonly float RIGHT_MARGIN       = 6.5f;
        public static readonly float LEFT_MARGIN        = -RIGHT_MARGIN;
        public static readonly float CAMERA_UPPER_POINT = 7.0f;
        public static readonly float CAMERA_DOWN_POINT  = -CAMERA_UPPER_POINT;
        public static readonly float CAMERA_RIGHT_POINT = 6.8f;
        public static readonly float CAMERA_LEFT_POINT  = -CAMERA_RIGHT_POINT;
        

        public static readonly string HORIZONTAL = "Horizontal";
        public static readonly string VERTICAL   = "Vertical";

        public static readonly string TAG_PLAYER = "Player";
        public static readonly string TAG_ENEMY  = "Enemy";
        public static readonly string TAG_LASER  = "Laser";
    }
}
