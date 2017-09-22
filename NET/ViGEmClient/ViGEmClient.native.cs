﻿using System;
using System.Runtime.InteropServices;

namespace Nefarius.ViGEm.Client
{
    using PVIGEM_CLIENT = IntPtr;
    using PVIGEM_TARGET = IntPtr;
    using PVIGEM_TARGET_ADD_RESULT = IntPtr;
    using PVIGEM_X360_NOTIFICATION = IntPtr;
    using PVIGEM_DS4_NOTIFICATION = IntPtr;

    partial class ViGEmClient
    {
        internal enum VIGEM_ERROR : UInt32
        {
            VIGEM_ERROR_NONE = 0x20000000,
            VIGEM_ERROR_BUS_NOT_FOUND = 0xE0000001,
            VIGEM_ERROR_NO_FREE_SLOT = 0xE0000002,
            VIGEM_ERROR_INVALID_TARGET = 0xE0000003,
            VIGEM_ERROR_REMOVAL_FAILED = 0xE0000004,
            VIGEM_ERROR_ALREADY_CONNECTED = 0xE0000005,
            VIGEM_ERROR_TARGET_UNINITIALIZED = 0xE0000006,
            VIGEM_ERROR_TARGET_NOT_PLUGGED_IN = 0xE0000007,
            VIGEM_ERROR_BUS_VERSION_MISMATCH = 0xE0000008,
            VIGEM_ERROR_BUS_ACCESS_FAILED = 0xE0000009,
            VIGEM_ERROR_CALLBACK_ALREADY_REGISTERED = 0xE0000010,
            VIGEM_ERROR_CALLBACK_NOT_FOUND = 0xE0000011,
            VIGEM_ERROR_BUS_ALREADY_CONNECTED = 0xE0000012
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct XUSB_REPORT
        {
            public ushort wButtons;
            public byte bLeftTrigger;
            public byte bRightTrigger;
            public short sThumbLX;
            public short sThumbLY;
            public short sThumbRX;
            public short sThumbRY;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct DS4_REPORT
        {
            byte bThumbLX;
            byte bThumbLY;
            byte bThumbRX;
            byte bThumbRY;
            ushort wButtons;
            byte bSpecial;
            byte bTriggerL;
            byte bTriggerR;
        }

        internal enum VIGEM_TARGET_TYPE : UInt32
        {
            // 
            // Microsoft Xbox 360 Controller (wired)
            // 
            Xbox360Wired,
            // 
            // Microsoft Xbox One Controller (wired)
            // 
            XboxOneWired,
            //
            // Sony DualShock 4 (wired)
            // 
            DualShock4Wired
        }

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        static extern PVIGEM_CLIENT vigem_alloc();

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        static extern void vigem_free(PVIGEM_CLIENT vigem);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        static extern VIGEM_ERROR vigem_connect(PVIGEM_CLIENT vigem);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        static extern void vigem_disconnect(PVIGEM_CLIENT vigem);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        internal static extern PVIGEM_TARGET vigem_target_x360_alloc();

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        internal static extern PVIGEM_TARGET vigem_target_ds4_alloc();

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        internal static extern void vigem_target_free(PVIGEM_TARGET target);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        internal static extern VIGEM_ERROR vigem_target_add(PVIGEM_CLIENT vigem, PVIGEM_TARGET target);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        static extern VIGEM_ERROR vigem_target_add_async(PVIGEM_CLIENT vigem, PVIGEM_TARGET target, PVIGEM_TARGET_ADD_RESULT result);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        internal static extern VIGEM_ERROR vigem_target_remove(PVIGEM_CLIENT vigem, PVIGEM_TARGET target);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        static extern VIGEM_ERROR vigem_target_x360_register_notification(PVIGEM_CLIENT vigem, PVIGEM_TARGET target, PVIGEM_X360_NOTIFICATION notification);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        static extern VIGEM_ERROR vigem_target_ds4_register_notification(PVIGEM_CLIENT vigem, PVIGEM_TARGET target, PVIGEM_DS4_NOTIFICATION notification);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        static extern void vigem_target_x360_unregister_notification(PVIGEM_TARGET target);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        static extern void vigem_target_ds4_unregister_notification(PVIGEM_TARGET target);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        static extern void vigem_target_set_vid(PVIGEM_TARGET target, ushort vid);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        static extern void vigem_target_set_pid(PVIGEM_TARGET target, ushort pid);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        static extern ushort vigem_target_get_vid(PVIGEM_TARGET target);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        static extern ushort vigem_target_get_pid(PVIGEM_TARGET target);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        internal static extern VIGEM_ERROR vigem_target_x360_update(PVIGEM_CLIENT vigem, PVIGEM_TARGET target, XUSB_REPORT report);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        internal static extern VIGEM_ERROR vigem_target_ds4_update(PVIGEM_CLIENT vigem, PVIGEM_TARGET target, DS4_REPORT report);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        static extern uint vigem_target_get_index(PVIGEM_TARGET target);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        static extern VIGEM_TARGET_TYPE vigem_target_get_type(PVIGEM_TARGET target);

        [DllImport("ViGEmClient.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        static extern bool vigem_target_is_attached(PVIGEM_TARGET target);
    }
}