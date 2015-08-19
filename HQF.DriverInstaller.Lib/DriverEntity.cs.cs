using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HQF.DriverInstaller.Lib
{
    public class DriverEntity
    {
        // Service Types (Bit Mask)
        public static readonly UInt32 SERVICE_KERNEL_DRIVER = 0x00000001;
        public static readonly UInt32 SERVICE_FILE_SYSTEM_DRIVER = 0x00000002;
        public static readonly UInt32 SERVICE_ADAPTER = 0x00000004;
        public static readonly UInt32 SERVICE_RECOGNIZER_DRIVER = 0x00000008;
        public static readonly UInt32 SERVICE_WIN32_OWN_PROCESS = 0x00000010;
        public static readonly UInt32 SERVICE_WIN32_SHARE_PROCESS = 0x00000020;
        public static readonly UInt32 SERVICE_INTERACTIVE_PROCESS = 0x00000100;
        public static readonly UInt32 SERVICE_WIN32 =
            SERVICE_WIN32_OWN_PROCESS | SERVICE_WIN32_SHARE_PROCESS;

        public static readonly UInt32 SERVICE_DRIVER =
            SERVICE_KERNEL_DRIVER | SERVICE_FILE_SYSTEM_DRIVER | SERVICE_RECOGNIZER_DRIVER;

        public static readonly UInt32 SERVICE_TYPE_ALL =
            SERVICE_WIN32 | SERVICE_ADAPTER | SERVICE_DRIVER | SERVICE_INTERACTIVE_PROCESS;

        // Start Type
        public static readonly UInt32 SERVICE_BOOT_START = 0x00000000;
        public static readonly UInt32 SERVICE_SYSTEM_START = 0x00000001;
        public static readonly UInt32 SERVICE_AUTO_START = 0x00000002;
        public static readonly UInt32 SERVICE_DEMAND_START = 0x00000003;
        public static readonly UInt32 SERVICE_DISABLED = 0x00000004;

        // Error control type
        public static readonly UInt32 SERVICE_ERROR_IGNORE = 0x00000000;
        public static readonly UInt32 SERVICE_ERROR_NORMAL = 0x00000001;
        public static readonly UInt32 SERVICE_ERROR_SEVERE = 0x00000002;
        public static readonly UInt32 SERVICE_ERROR_CRITICAL = 0x00000003;

        // Controls
        public static readonly UInt32 SERVICE_CONTROL_STOP = 0x00000001;
        public static readonly UInt32 SERVICE_CONTROL_PAUSE = 0x00000002;
        public static readonly UInt32 SERVICE_CONTROL_CONTINUE = 0x00000003;
        public static readonly UInt32 SERVICE_CONTROL_INTERROGATE = 0x00000004;
        public static readonly UInt32 SERVICE_CONTROL_SHUTDOWN = 0x00000005;

        // Service object specific access type
        public static readonly UInt32 SERVICE_QUERY_CONFIG = 0x0001;
        public static readonly UInt32 SERVICE_CHANGE_CONFIG = 0x0002;
        public static readonly UInt32 SERVICE_QUERY_STATUS = 0x0004;
        public static readonly UInt32 SERVICE_ENUMERATE_DEPENDENTS = 0x0008;
        public static readonly UInt32 SERVICE_START = 0x0010;
        public static readonly UInt32 SERVICE_STOP = 0x0020;

        public static readonly UInt32 SERVICE_ALL_ACCESS = 0xF01FF;

        // Service Control Manager object specific access types
        public static readonly UInt32 SC_MANAGER_ALL_ACCESS = 0xF003F;
        public static readonly UInt32 SC_MANAGER_CREATE_SERVICE = 0x0002;
        public static readonly UInt32 SC_MANAGER_CONNECT = 0x0001;
        public static readonly UInt32 SC_MANAGER_ENUMERATE_SERVICE = 0x0004;
        public static readonly UInt32 SC_MANAGER_LOCK = 0x0008;
        public static readonly UInt32 SC_MANAGER_MODIFY_BOOT_CONFIG = 0x0020;
        public static readonly UInt32 SC_MANAGER_QUERY_LOCK_STATUS = 0x0010;

        // These are the generic rights.
        public static readonly UInt32 GENERIC_READ = 0x80000000;
        public static readonly UInt32 GENERIC_WRITE = 0x40000000;
        public static readonly UInt32 GENERIC_EXECUTE = 0x20000000;
        public static readonly UInt32 GENERIC_ALL = 0x10000000;

        //Driver Device Name
        public static readonly String TaskManager_Driver_Nt_Device_Name = "\\Device\\TaskManagerDevice";
        public static readonly String TaskManager_Driver_Dos_Device_Name = "\\DosDevices\\TaskManagerDevice";



        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SECURITY_ATTRIBUTES
        {
            public UInt32 nLength;
            public IntPtr lpSecurityDescriptor;
            public bool bInheritHandle;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct OVERLAPPED
        {
            public UInt32 Internal;
            public UInt32 InternalHigh;
            public UInt32 Offset;
            public UInt32 OffsetHigh;
            public IntPtr hEvent;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SERVICE_STATUS
        {
            public UInt32 dwServiceType;
            public UInt32 dwCurrentState;
            public UInt32 dwControlsAccepted;
            public UInt32 dwWin32ExitCode;
            public UInt32 dwServiceSpecificExitCode;
            public UInt32 dwCheckPoint;
            public UInt32 dwWaitHint;
        }
    }
}
