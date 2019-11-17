using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace apex
{
    class SDK
    {
        public static Vector3 GetEntityBasePosition(ulong ent)
        {
            return Driver.Read<Vector3>(ent + Offsets.origin, 1);
        }
        public static ulong GetEntityBoneArray(ulong ent)
        {
            return Driver.Read<ulong>(ent + Offsets.bones, 1);
        }

        public static Vector3 GetEntityBonePosition(ulong ent, int BoneId, Vector3 BasePosition)
        {
            ulong pBoneArray = GetEntityBoneArray(ent);

            Vector3 EntityHead = new Vector3();

            EntityHead.X = Driver.Read<float>(pBoneArray + 0xCC + ((ulong)BoneId * 0x30), 1) + BasePosition.X;
            EntityHead.Y = Driver.Read<float>(pBoneArray + 0xDC + ((ulong)BoneId * 0x30), 1) + BasePosition.Y;
            EntityHead.Z = Driver.Read<float>(pBoneArray + 0xEC + ((ulong)BoneId * 0x30), 1) + BasePosition.Z;

            return EntityHead;
        }

        public static Vector3 GetViewAngles(ulong ent)
        {
            return Driver.Read<Vector3>(ent + Offsets.viewangles, 1);
        }

        public static void SetViewAngles(ulong ent, Vector3 angles)
        {
            Driver.Write<Vector3>(ent + Offsets.viewangles, angles, 1);
        }

        public static Vector3 GetCamPos(ulong ent)
        {
            return Driver.Read<Vector3>(ent + Offsets.camerapos, 1);
        }

        public static Vector3 CalcAngle(Vector3 src, Vector3 dst)
        {
            Vector3 angle = new Vector3();
            Vector3 delta = src - dst;

            double hYp = Math.Sqrt((double)(delta.X * delta.X) + (delta.Y * delta.Y));
            angle.X = (float)(Math.Atan(delta.Z / hYp) * 57.295779513082f);
            angle.Y = (float)(Math.Atan(delta.Y / delta.X) * 57.295779513082f);
            if (delta.X >= 0.0) angle.Y += 180.0f;

            return angle;
        }

        public static void NormalizeAngles(ref Vector3 angle)
        {
            while (angle.X > 89.0f)
                angle.X -= 180.0f;

            while (angle.X < -89.0f)
                angle.X += 180.0f;

            while (angle.Y > 180.0f)
                angle.Y -= 360.0f;

            while (angle.Y < -180.0f)
                angle.Y += 360.0f;
        }

        public static float GetFov(Vector3 viewAngle, Vector3 aimAngle)
        {
            Vector3 delta = aimAngle - viewAngle;
            NormalizeAngles(ref delta);

            return (float)(Math.Sqrt(Math.Pow(delta.X, 2.0f) + Math.Pow(delta.Y, 2.0f)));
        }
    }
}
