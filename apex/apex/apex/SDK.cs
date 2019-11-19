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
            Vector3 returnval = new Vector3();
            
            if (number == 0)
            {
                returnval = Driver.Helper1.Read<Vector3>(ent + Offsets.origin);
            }
            if (number == 1)
            {
                returnval = Driver.Helper2.Read<Vector3>(ent + Offsets.origin);
            }
            if (number == 2)
            {
                returnval = Driver.Helper3.Read<Vector3>(ent + Offsets.origin);
            }

            return returnval;
        }
        public static ulong GetEntityBoneArray(ulong ent, int number)
        {
            ulong returnval = 0;
            
            if (number == 0)
            {
                returnval = Driver.Helper1.Read<ulong>(ent + Offsets.bones);
            }
            if (number == 1)
            {
                returnval = Driver.Helper2.Read<ulong>(ent + Offsets.bones);
            }
            if (number == 2)
            {
                returnval = Driver.Helper3.Read<ulong>(ent + Offsets.bones);
            }

            return returnval;
        }

        public static Vector3 GetEntityBonePosition(ulong ent, int BoneId, Vector3 BasePosition, int number)
        {
            ulong pBoneArray = GetEntityBoneArray(ent, number);

            Vector3 EntityHead = new Vector3();

            if (number == 0)
            {
                EntityHead.X = Driver.Helper1.Read<float>(pBoneArray + 0xCC + ((ulong)BoneId * 0x30)) + BasePosition.X;
                EntityHead.Y = Driver.Helper1.Read<float>(pBoneArray + 0xDC + ((ulong)BoneId * 0x30)) + BasePosition.Y;
                EntityHead.Z = Driver.Helper1.Read<float>(pBoneArray + 0xEC + ((ulong)BoneId * 0x30)) + BasePosition.Z;
            }
            if (number == 1)
            {
                EntityHead.X = Driver.Helper2.Read<float>(pBoneArray + 0xCC + ((ulong)BoneId * 0x30)) + BasePosition.X;
                EntityHead.Y = Driver.Helper2.Read<float>(pBoneArray + 0xDC + ((ulong)BoneId * 0x30)) + BasePosition.Y;
                EntityHead.Z = Driver.Helper2.Read<float>(pBoneArray + 0xEC + ((ulong)BoneId * 0x30)) + BasePosition.Z;
            }
            if (number == 2)
            {
                EntityHead.X = Driver.Helper3.Read<float>(pBoneArray + 0xCC + ((ulong)BoneId * 0x30)) + BasePosition.X;
                EntityHead.Y = Driver.Helper3.Read<float>(pBoneArray + 0xDC + ((ulong)BoneId * 0x30)) + BasePosition.Y;
                EntityHead.Z = Driver.Helper3.Read<float>(pBoneArray + 0xEC + ((ulong)BoneId * 0x30)) + BasePosition.Z;
            }

            return EntityHead;
        }

        public static Vector3 GetViewAngles(ulong ent, int number)
        {
            Vector3 returnval = new Vector3();

            if (number == 0)
            {
                returnval = Driver.Helper1.Read<Vector3>(ent + Offsets.viewangles);
            }
            if (number == 1)
            {
                returnval = Driver.Helper2.Read<Vector3>(ent + Offsets.viewangles);
            }
            if (number == 2)
            {
                returnval = Driver.Helper3.Read<Vector3>(ent + Offsets.viewangles);
            }

            return returnval;
        }

        public static void SetViewAngles(ulong ent, Vector3 angles, int number)
        {          
            if (number == 0)
            {
                Driver.Helper1.Write<Vector3>(ent + Offsets.viewangles, angles);
            }
            if (number == 1)
            {
                Driver.Helper2.Write<Vector3>(ent + Offsets.viewangles, angles);
            }
            if (number == 2)
            {
                Driver.Helper3.Write<Vector3>(ent + Offsets.viewangles, angles);
            }
        }

        public static Vector3 GetCamPos(ulong ent, int number)
        {
            Vector3 returnval = new Vector3();

            if (number == 0)
            {
                returnval = Driver.Helper1.Read<Vector3>(ent + Offsets.camerapos);
            }
            if (number == 1)
            {
                returnval = Driver.Helper2.Read<Vector3>(ent + Offsets.camerapos);
            }
            if (number == 2)
            {
                returnval = Driver.Helper3.Read<Vector3>(ent + Offsets.camerapos);
            }

            return returnval;
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
