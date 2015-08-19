using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HQF.DriverInstaller.Lib
{
    public class DriverDAL
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateFile(
            String lpFileName,
            UInt32 dwDesiredAccess,
            UInt32 dwShareMode,
            ref DriverEntity.SECURITY_ATTRIBUTES lpSecurityAttributes,
            UInt32 dwCreationDisposition,
            UInt32 dwFlagsAndAttributes,
            IntPtr hTemplateFile
            );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool WriteFile(
            IntPtr hFile,
            byte[] lpBuffer,
            UInt32 nNumberOfBytesToWrite,
            ref UInt32 lpNumberOfBytesWritten,
            ref DriverEntity.OVERLAPPED lpOverlapped
            );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool DeviceIoControl(
            IntPtr hDevice,
            UInt32 dwIoControlCode,
            byte[] lpInBuffer,
            UInt32 nInBufferSize,
            byte[] lpOutBuffer,
            UInt32 nOutBufferSize,
            ref UInt32 lpBytesReturned,
            ref DriverEntity.OVERLAPPED lpOverlapped
            );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(
            IntPtr hObject
            );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateEvent(
            ref DriverEntity.SECURITY_ATTRIBUTES lpEventAttributes,
            bool bManualReset,
            bool bInitialState,
            String lpName
            );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern UInt32 WaitForSingleObject(
            IntPtr hHandle,
            UInt32 dwMilliseconds
            );

        [DllImport("kernel32.dll")]
        public static extern UInt32 GetLastError();


        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr OpenSCManager(
            String lpMachineName,
            String lpDatabaseName,
            UInt32 dwDesiredAccess
            );

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateService(
            IntPtr hSCManager,
            String lpServiceName,
            String lpDisplayName,
            UInt32 dwDesiredAccess,
            UInt32 dwServiceType,
            UInt32 dwStartType,
            UInt32 dwErrorControl,
            String lpBinaryPathName,
            String lpLoadOrderGroup,
            ref UInt32 lpdwTagId,
            String lpDependencies,
            String lpServiceStartName,
            String lpPassword
            );

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseServiceHandle(
            IntPtr hSCObject
            );

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern bool StartService(
            IntPtr hService,
            UInt32 dwNumServiceArgs,
            String lpServiceArgVectors
            );


        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr OpenService(
            IntPtr hSCManager,
            String lpServiceName,
            UInt32 dwDesiredAccess
            );

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern bool DeleteService(
            IntPtr hService
            );

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern bool ControlService(
            IntPtr hService,
            UInt32 dwControl,
            ref DriverEntity.SERVICE_STATUS lpServiceStatus
            );
    }
}
