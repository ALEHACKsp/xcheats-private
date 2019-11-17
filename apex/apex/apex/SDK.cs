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
        public static Vector3 GetEntityBasePosition(ulong ent, int number)
        {
            return Driver.Read<Vector3>(ent + Offsets.origin, number);
        }
        public static ulong GetEntityBoneArray(ulong ent, int number)
        {
            return Driver.Read<ulong>(ent + Offsets.bones, number);
        }

        public static Vector3 GetEntityBonePosition(ulong ent, int BoneId, Vector3 BasePosition, int number)
        {
            ulong pBoneArray = GetEntityBoneArray(ent, number);

            Vector3 EntityHead = new Vector3();

            EntityHead.X = Driver.Read<float>(pBoneArray + 0xCC + ((ulong)BoneId * 0x30), number) + BasePosition.X;
            EntityHead.Y = Driver.Read<float>(pBoneArray + 0xDC + ((ulong)BoneId * 0x30), number) + BasePosition.Y;
            EntityHead.Z = Driver.Read<float>(pBoneArray + 0xEC + ((ulong)BoneId * 0x30), number) + BasePosition.Z;

            return EntityHead;
        }

        public static Vector3 GetViewAngles(ulong ent, int number)
        {
            return Driver.Read<Vector3>(ent + Offsets.viewangles, number);
        }

        public static void SetViewAngles(ulong ent, Vector3 angles, int number)
        {
            Driver.Write<Vector3>(ent + Offsets.viewangles, angles, number);
        }

        public static Vector3 GetCamPos(ulong ent, int number)
        {
            return Driver.Read<Vector3>(ent + Offsets.camerapos, number);
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

        public static Vector3 NormalizeAngles(Vector3 angle)
        {
            while (angle.X > 89.0f)
                angle.X -= 180.0f;

            while (angle.X < -89.0f)
                angle.X += 180.0f;

            while (angle.Y > 180.0f)
                angle.Y -= 360.0f;

            while (angle.Y < -180.0f)
                angle.Y += 360.0f;

            return angle;
        }

        public static float GetFov(Vector3 viewAngle, Vector3 aimAngle)
        {
            Vector3 delta = aimAngle - viewAngle;
            delta = NormalizeAngles(delta);

            return (float)(Math.Sqrt(Math.Pow(delta.X, 2.0f) + Math.Pow(delta.Y, 2.0f)));
        }
    }
}
