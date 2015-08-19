using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQF.DriverInstaller.Lib
{
    public class DriverBLL
    {
        /// <summary>
        /// 启动驱动程序
        /// </summary>
        /// <param name="svcName"></param>
        /// <returns></returns>
        public bool StartDriver(String svcName)
        {
            IntPtr scManagerHandle;
            IntPtr schDriverService;

            //打开服务控制台管理器
            scManagerHandle = DriverDAL.OpenSCManager(null, null, DriverEntity.SC_MANAGER_CREATE_SERVICE);
            if (null == scManagerHandle || IntPtr.Zero == scManagerHandle)
            {
                return false;
            }

            //打开服务
            schDriverService = DriverDAL.OpenService(scManagerHandle, svcName, DriverEntity.SERVICE_ALL_ACCESS);
            if (null == schDriverService || IntPtr.Zero == schDriverService)
            {
                DriverDAL.CloseServiceHandle(scManagerHandle);
                return false;
            }

            if (false == DriverDAL.StartService(schDriverService, 0, null))
            {
                DriverDAL.CloseServiceHandle(schDriverService);
                DriverDAL.CloseServiceHandle(scManagerHandle);
                return false;
            }

            DriverDAL.CloseServiceHandle(schDriverService);
            DriverDAL.CloseServiceHandle(scManagerHandle);

            return true;
        }


        /// <summary>
        /// 停止驱动程序服务
        /// </summary>
        /// <param name="svcName"></param>
        /// <returns></returns>
        public bool StopDriver(String svcName)
        {
            IntPtr scManagerHandle;
            IntPtr schDriverService;

            DriverEntity.SERVICE_STATUS serviceStatus;

            //打开服务控制台管理器
            scManagerHandle = DriverDAL.OpenSCManager(null, null, DriverEntity.SC_MANAGER_CREATE_SERVICE);
            if (null == scManagerHandle || IntPtr.Zero == scManagerHandle)
            {
                return false;
            }

            //打开服务
            schDriverService = DriverDAL.OpenService(scManagerHandle, svcName, DriverEntity.SERVICE_ALL_ACCESS);
            if (null == schDriverService || IntPtr.Zero == schDriverService)
            {
                DriverDAL.CloseServiceHandle(scManagerHandle);
                return false;
            }

            serviceStatus = new DriverEntity.SERVICE_STATUS();

            //停止服务
            if (false == DriverDAL.ControlService(schDriverService, DriverEntity.SERVICE_CONTROL_STOP, ref serviceStatus))
            {
                DriverDAL.CloseServiceHandle(schDriverService);
                DriverDAL.CloseServiceHandle(scManagerHandle);

                return false;
            }
            else
            {
                DriverDAL.CloseServiceHandle(schDriverService);
                DriverDAL.CloseServiceHandle(scManagerHandle);

                return true;
            }
        }


        /// <summary>
        /// 判断驱动程序是否已经安装
        /// </summary>
        /// <param name="svcName"></param>
        /// <returns></returns>
        public bool DriverIsInstalled(string svcName)
        {
            IntPtr scManagerHandle;
            IntPtr schDriverService;

            //打开服务控制台管理器
            scManagerHandle = DriverDAL.OpenSCManager(null, null, DriverEntity.SC_MANAGER_ALL_ACCESS);
            if (null == scManagerHandle || IntPtr.Zero == scManagerHandle)
            {
                return false;
            }

            //打开驱动程序服务
            schDriverService = DriverDAL.OpenService(scManagerHandle, svcName, DriverEntity.SERVICE_ALL_ACCESS);
            if (null == schDriverService || IntPtr.Zero == schDriverService)
            {
                DriverDAL.CloseServiceHandle(scManagerHandle);
                return false;
            }

            DriverDAL.CloseServiceHandle(schDriverService);
            DriverDAL.CloseServiceHandle(scManagerHandle);

            return true;
        }


        /// <summary>
        /// 安装驱动程序服务
        /// </summary>
        /// <param name="svcDriverPath"></param>
        /// <param name="svcDriverName"></param>
        /// <param name="svcDisplayName"></param>
        /// <returns></returns>
        public bool DriverInstall(String svcDriverPath, String svcDriverName, String svcDisplayName)
        {
            UInt32 lpdwTagId;
            IntPtr scManagerHandle;
            IntPtr schDriverService;

            //打开服务控制台管理器
            scManagerHandle = DriverDAL.OpenSCManager(null, null, DriverEntity.SC_MANAGER_CREATE_SERVICE);
            if (null == scManagerHandle || IntPtr.Zero == scManagerHandle)
            {
                return false;
            }
            if (DriverIsInstalled(svcDriverName) == false)
            {
                lpdwTagId = 0;
                schDriverService = DriverDAL.CreateService(
                    scManagerHandle, svcDriverName, svcDisplayName,
                    DriverEntity.SERVICE_ALL_ACCESS,
                    DriverEntity.SERVICE_KERNEL_DRIVER,
                    DriverEntity.SERVICE_DEMAND_START,
                    DriverEntity.SERVICE_ERROR_NORMAL,
                    svcDriverPath, null,
                    ref lpdwTagId,
                    null, null, null
                    );

                DriverDAL.CloseServiceHandle(scManagerHandle);
                if (null == schDriverService || IntPtr.Zero == schDriverService)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            DriverDAL.CloseServiceHandle(scManagerHandle);
            return true;
        }


        /// <summary>
        /// 卸载驱动程序服务
        /// </summary>
        /// <param name="svcName"></param>
        public void DriverUnInstall(String svcName)
        {
            IntPtr scManagerHandle;
            IntPtr schDriverService;

            //打开服务控制台管理器
            scManagerHandle = DriverDAL.OpenSCManager(null, null, DriverEntity.SC_MANAGER_ALL_ACCESS);
            if (null == scManagerHandle || IntPtr.Zero == scManagerHandle)
            {
                return;
            }

            //打开驱动程序服务
            schDriverService = DriverDAL.OpenService(scManagerHandle, svcName, DriverEntity.SERVICE_ALL_ACCESS);
            if (null == schDriverService || IntPtr.Zero == schDriverService)
            {
                DriverDAL.CloseServiceHandle(scManagerHandle);
                return;
            }
            else
            {
                DriverDAL.DeleteService(schDriverService);

                DriverDAL.CloseServiceHandle(schDriverService);
                DriverDAL.CloseServiceHandle(scManagerHandle);
            }
        }
    }
}
