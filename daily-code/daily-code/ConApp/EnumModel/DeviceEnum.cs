using System.ComponentModel;

namespace ConApp.EnumModel
{
    //https://msdn.microsoft.com/zh-cn/library/windows/hardware/aa389273(v=vs.85).aspx
    public enum Cooling_Device_Enum
    {
        Win32_Fan,                              //Represents the properties of a fan device in the computer system.
        Win32_HeatPipe,                      //Represents the properties of a heat pipe cooling device.
        Win32_Refrigeration,                //Represents the properties of a refrigeration device.
        Win32_TemperatureProbe        //Represents the properties of a temperature sensor (electronic thermometer).
    }

    public enum Input_Device_Enum
    {
        Win32_Keyboard,                         // Represents a keyboard installed on a computer system running Windows.
        Win32_PointingDevice                 // Represents an input device used to point to and select regions on the display of a computer system running Windows.
    }

    public enum Mass_Storage_Enum
    {
        Win32_AutochkSetting,                 //Represents the settings for the autocheck operation of a disk.
        Win32_CDROMDrive,                    //Represents a CD-ROM drive on a computer system running Windows.
        Win32_DiskDrive,                          //Represents a physical disk drive as seen by a computer running the Windows operating system.
        Win32_FloppyDrive,                      //Manages the capabilities of a floppy disk drive.
        Win32_PhysicalMedia,                  //Represents any type of documentation or storage medium.
        Win32_TapeDrive                         //Represents a tape drive on a computer system running Windows.
    }

    public enum Motherboard_Controller_Port_Enum
    {
        Win32_1394Controller,                        //Represents the capabilities and management of a 1394 controller.
        Win32_1394ControllerDevice,              //Relates the high-speed serial bus (IEEE 1394 Firewire) Controller and the CIM_LogicalDevice instance connected to it.
        Win32_AllocatedResource,                   //Relates a logical device to a system resource.
        Win32_AssociatedProcessorMemory,   //Relates a processor and its cache memory.
        Win32_BaseBoard,                       //Represents a baseboard (also known as a motherboard or system board).
        Win32_BIOS,                                //Represents the attributes of the computer system's basic input or output services (BIOS) that are installed on the computer.
        Win32_Bus,                                  //Represents a physical bus as seen by a Windows operating system.
        Win32_CacheMemory,                 //Represents cache memory (internal and external) on a computer system.
        Win32_ControllerHasHub,           //Represents the hubs downstream from the universal serial bus (USB) controller.
        Win32_DeviceBus,                       //Relates a system bus and a logical device using the bus.
        Win32_DeviceMemoryAddress,    //Represents a device memory address on a Windows system.
        Win32_DeviceSettings,                //Relates a logical device and a setting that can be applied to it.
        Win32_DMAChannel,                   //Represents a direct memory access (DMA) channel on a computer system running Windows.
        Win32_FloppyController,              //Represents the capabilities and management capacity of a floppy disk drive controller.
        Win32_IDEController,                   //Represents the capabilities of an Integrated Drive Electronics(IDE) controller device.
        Win32_IDEControllerDevice,         //Association class that relates an IDE controller and the logical device.
        Win32_InfraredDevice,                 //Represents the capabilities and management of an infrared device.
        Win32_IRQResource,                    //Represents an interrupt request line (IRQ) number on a Windows computer system.
        Win32_MemoryArray,                   //Represents the properties of the computer system memory array and mapped addresses.
        Win32_MemoryArrayLoction,        //Relates a logical memory array and the physical memory array upon which it exists.
        Win32_MemoryDevice,                 //Represents the properties of a computer system's memory device along with its associated mapped addresses.
        Win32_MemoryDeviceArray,         //Relates a memory device and the memory array in which it resides.
        Win32_MemoryDeviceLocation,    //Association class that relates a memory device and the physical memory on which it exists.
        Win32_MotherboardDevice,          //Represents a device that contains the central components of the computer system running Windows.
        Win32_OnBoardDevice,                 //Represents common adapter devices built into the motherboard (system board).
        Win32_ParallelPort,                       //Represents the properties of a parallel port on a computer system running Windows.
        Win32_PCMCIAController,             //Manages the capabilities of a Personal Computer Memory Card Interface Adapter (PCMCIA) controller device.
        Win32_PhysicalMemory,                //Represents a physical memory device located on a computer as available to the operating system.
        Win32_PhysicalMemoryArray,        //Represents details about the computer system's physical memory.
        Win32_PhysicalMemoryLocation,   //Relates an array of physical memory and its physical memory.
        Win32_PNPAllocatedResource,      //Represents an association between logical devices and system resources.
        Win32_PNPDevice,                        //Relates a device (known to Configuration Manager as a PNPEntity), and the function it performs.
        Win32_PNPEntity,                          //Represents the properties of a Plug and Play device.
        Win32_PortConnector,                   //Represents physical connection ports, such as DB-25 pin male, Centronics, and PS/2.
        Win32_PortResource,                     //Represents an I/O port on a computer system running Windows.
        Win32_Processor,                           //Represents a device capable of interpreting a sequence of machine instructions on a computer system running Windows.
        Win32_SCSIController,                    //Represents a small computer system interface (SCSI) controller on a computer system running Windows.
        Win32_SCSIControllerDevice,          //Relates a SCSI controller and the logical device(disk drive) connected to it.
        Win32_SerialPort,                            //Represents a serial port on a computer system running Windows.
        Win32_SerialPortConfiguration,       //Represents the settings for data transmission on a Windows serial port.
        Win32_SerialPortSetting,                 //Relates a serial port and its configuration settings.
        Win32_SMBIOSMemory,                  //Represents the capabilities and management of memory-related logical devices.
        Win32_SoundDevice,                       //Represents the properties of a sound device on a computer system running Windows.
        Win32_SystemBIOS,                         //Relates a computer system (including data such as startup properties, time zones, boot configurations, or administrative passwords) and a system BIOS(services, languages, and system management properties).
        Win32_SystemDriverPNPEntity,         //Relates a Plug and Play device on the Windows computer system and the driver that supports the Plug and Play device.
        Win32_SystemEnclosure,                  //Represents the properties associated with a physical system enclosure.
        Win32_SystemMemoryResource,     //Represents a system memory resource on a Windows system.
        Win32_SystemSlot,                           //Represents physical connection points including ports, motherboard slots and peripherals, and proprietary connections points.
        Win32_USBController,                       //Manages the capabilities of a universal serial bus (USB) controller.
        Win32_USBControllerDevice,             //Relates a USB controller and the CIM_LogicalDevice instances connected to it.
        Win32_USBHub                                //Represents the management characteristics of a USB hub.
    }

    public enum Networking_Device_Enum
    {
        [Description("Represents a network adapter on a computer system running Windows")]
        Win32_NetworkAdapter,

        [Description("Represents the attributes and behaviors of a network adapter. The class is not guaranteed to be supported after the ratification of the Distributed Management Task Force(DMTF) CIM network")]
        Win32_NetworkAdapterConfiguration,

        [Description("Relates a network adapter and its configuration settings.")]
        Win32_NetworkAdapterSetting
    }

    public enum Power_Enum
    {
        Win32_Battery,                                      //Represents a battery connected to the computer system.
        Win32_CurrentProbe,                            //Represents the properties of a current monitoring sensor (ammeter).
        Win32_PortableBattery,                         //Represents the properties of a portable battery, such as one used for a notebook computer.
        Win32_PowerManagementEvent,          //Represents power management events resulting from power state changes.
        Win32_VoltageProbe,                            //Represents the properties of a voltage sensor (electronic voltmeter).
    }

    public enum Printing_Enum
    {
        Win32_DriverForDevice,                      //Relates a printer to a printer driver.
        Win32_Printer,                                    //Represents a device connected to a computer system running Windows that is capable of reproducing a visual image on a medium.
        Win32_PrinterConfiguration,               //Defines the configuration for a printer device.
        Win32_PrinterController,                     //Relates a printer and the local device to which the printer is connected.
        Win32_PrinterDriver,                           //Represents the drivers for a Win32_Printer instance.
        Win32_PrinterDriverDll,                       //Relates a local printer and its driver file (not the driver itself).
        Win32_PrinterSetting,                         //Relates a printer and its configuration settings.
        Win32_PrintJob,                                  //Represents a print job generated by a Windows-based application.
        Win32_TCPIPPrinterPort,                     //Represents a TCP/IP service access point.
    }

    public enum Telephony_Enum
    {
        Win32_POTSModem,                           //Represents the services and characteristics of a Plain Old Telephone Service (POTS) modem on a computer system running Windows.
        Win32_POTSModemToSerialPort         //Relates a modem and the serial port the modem uses.
    }

    public enum Video_Monitor_Enum
    {
        Win32_DesktopMonitor,                        //Represents the type of monitor or display device attached to the computer system.
        Win32_DisplayControllerConfiguration, //Represents the video adapter configuration information of a computer system running Windows. This class is obsolete.In place of this class, use the properties in the Win32_VideoController, Win32_DesktopMonitor, and CIM_VideoControllerResolution classes.
        Win32_VideoController,                        //Represents the capabilities and management capacity of the video controller on a computer system running Windows.
        Win32_VideoSettings                            //Relates a video controller and video settings that can be applied to it.
    }
}