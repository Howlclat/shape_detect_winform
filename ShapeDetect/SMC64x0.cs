using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace csSMC6X
{
    //
    // ��������, 6200�����ô���������
    enum SMC6X_CONNECTION_TYPE
    {
        SMC6X_CONNECTION_COM = 1,
        SMC6X_CONNECTION_ETH = 2,
        SMC6X_CONNECTION_USB = 3,
        SMC6X_CONNECTION_PCI = 4,
    };

    enum ERR_CODE_SMC6X
    {
        ERRCODE_UNKNOWN = 1,
        ERRCODE_PARAERR = 2,
        ERRCODE_TIMEOUT = 3,
        ERRCODE_CONTROLLERBUSY = 4,
        ERRCODE_CONNECT_TOOMANY = 5,

        ERRCODE_OS_ERR = 6,
        ERRCODE_CANNOT_OPEN_COM = 7,
        ERRCODE_CANNOT_CONNECTETH = 8,
        ERRCODE_HANDLEERR = 9, //���Ӵ���
        ERRCODE_SENDERR = 10, //���Ӵ���
        ERRCODE_GFILE_ERR = 11, //G�ļ��﷨����
        ERRCODE_FIRMWAREERR = 12, //�̼��ļ�����

        ERRCODE_FILENAME_TOOLONG = 13, //�ļ���̫��
        ERRCODE_FIRMWAR_MISMATCH = 14, //�̼��ļ���ƥ��

        ERRCODE_CARD_NOTSUPPORT = 15, //��Ӧ�Ŀ���֧���������


        ERRCODE_BUFFER_TOO_SMALL = 15, //����Ļ���̫С
        ERRCODE_NEED_PASSWORD = 16,    //���뱣��
        ERRCODE_PASSWORD_ENTER_TOOFAST = 17,    //��������̫��



        ERRCODE_GET_LENGTH_ERR = 100, //�յ������ݰ��ĳ��ȴ��� ���������ɺ󲻻����, �ַ����ӿ�ʱ���ܳ������峤��

        ERRCODE_COMPILE_OFFSET = 1000, //�ļ��������


        ERRCODE_CONTROLLERERR_OFFSET = 100000, //���������洫���Ĵ��󣬼������ƫ��

    };


    //[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    class SMC6X
    {
        /*********************************************************
        ��������
        **********************************************************/

        /*************************************************************
        ˵�������������������
        ���룺��
        �����������phandle
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCOpen")]//, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
            public static extern Int32 SMCOpen(SMC6X_CONNECTION_TYPE type, string pconnectstring , ref IntPtr phandle);
            //Int32 SMCOpen(SMC6X_CONNECTION_TYPE type, ref Byte pconnectstring ,ref IntPtr phandle);

        /*************************************************************
        ˵�������������������
        ���룺��
        �����������phandle
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCOpenCom")]
            public static extern Int32 SMCOpenCom(Int32 comid, ref IntPtr phandle);
            //Int32 SMCOpenCom(uint comid, ref IntPtr phandle);

        /*************************************************************
        ˵�������������������
        ���룺IP��ַ���ַ����ķ�ʽ����
        �����������phandle
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCOpenEth")]
            public static extern Int32 SMCOpenEth(string ipaddr, ref IntPtr phandle);
            //Int32 __stdcall SMCOpenEth(ref Byte ipaddr, ref IntPtr phandle);

        /*************************************************************
        ˵�������������������
        ���룺IP��ַ��32λ����IP��ַ����, ע���ֽ�˳��
        �����������phandle
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCOpenEth2")]
            public static extern Int32 SMCOpenEth2(Int32 straddr, ref IntPtr phandle);
            //Int32 __stdcall SMCOpenEth2(struct in_addr straddr, ref IntPtr phandle);

        /*************************************************************
        ˵�����رտ���������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCClose")]
            public static extern Int32 SMCClose(IntPtr phandle);
            //Int32 __stdcall SMCClose(IntPtr  phandle);


        /*************************************************************
        ˵�����������ʱ�ȴ�ʱ��
        ���룺������phandle ����ʱ��
        �����
        ����ֵ��������
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCSetTimeOut")]
            public static extern Int32 SMCSetTimeOut(IntPtr phandle, Int32 timems);
        //[DllImport("smc6x.dll", EntryPoint = "")] Int32 __stdcall SMCSetTimeOut(IntPtr  phandle, Int32 timems);

        /*************************************************************
        ˵�����������ʱ�ȴ�ʱ��
        ���룺������phandle 
        ���������ʱ��
        ����ֵ��������
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCGetTimeOut")]
            public static extern Int32 SMCGetTimeOut(IntPtr phandle, ref Int32 ptimems);
        //[DllImport("smc6x.dll", EntryPoint = "")] Int32 __stdcall SMCGetTimeOut(IntPtr  phandle, ref Int32 ptimems);

        /*************************************************************
        ˵������ȡ��ʱ������Ľ���
        ���룺������phandle 
        �����
        ����ֵ�����ȣ� ���㣬 
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCGetProgress")]
         public static extern float SMCGetProgress(IntPtr phandle);
       // float  __stdcall SMCGetProgress(IntPtr  phandle);


        /**********************************************
            command �����б�
        *******************************************/


        /*************************************************************
        ˵����//��ȡϵͳ״̬
        ���룺������phandle
        �����״̬
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetState")]
         public static extern float SMCGetState(IntPtr phandle,ref Byte pstate);
        //[DllImport("smc6x.dll", EntryPoint = "")] Int32 __stdcall SMCGetState(IntPtr phandle,ref Byte  pstate);

        /*************************************************************
        ˵����//��ȡ���ӿ�����������
        ���룺������phandle
        �����
        ����ֵ������������0
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCGetAxises")]
         public static extern Byte SMCGetAxises(IntPtr phandle);
         //Byte __stdcall SMCGetAxises(SMCHANDLE handle);

        /*************************************************************
        ˵�������س����ļ� ����ǰ�����һ��
        ���룺������phandle �ļ���
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownProgram")]
         public static extern Int32 SMCDownProgram(IntPtr phandle, string pfilename, string pfilenameinControl);

        /*************************************************************
        ˵�������س����ļ� ����ǰ�����һ��
        ���룺������phandle buff ���������ļ�������
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownMemProgram")]
         public static extern Int32 SMCDownMemProgram(IntPtr phandle, string pbuffer, Int32 buffsize, string pfilenameinControl);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCDownProgram(SMCHANDLE handle, string pfilename, string pfilenameinControl);

        /*************************************************************
        ˵�������س����ļ� ����ʱ�ļ���
        ���룺������phandle buff ���������ļ�������
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownProgramToTemp")]
         public static extern Int32 SMCDownProgramToTemp(IntPtr phandle, string pfilename);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCDownProgramToTemp(SMCHANDLE handle, string pfilename);

        /*************************************************************
        ˵�������س����ļ� ����ʱ�ļ���
        ���룺������phandle buff ���������ļ�������
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownMemProgramToTemp")]
         public static extern Int32 SMCDownMemProgramToTemp(IntPtr phandle, string pbuffer, Int32 buffsize);


        /*************************************************************
        ˵��������
        ���룺������phandle �ļ����� ��ΪNULL��ʱ������ȱʡ�ļ�
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCRunProgramFile")]
        public static extern Int32 SMCRunProgramFile(IntPtr phandle, string pfilenameinControl);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCRunProgramFile(SMCHANDLE handle, string pfilenameinControl);


        /*************************************************************
        ˵�������ص�ram������
        ���룺������phandle �ļ���
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownProgramToRamAndRun")]
        public static extern  Int32 SMCDownProgramToRamAndRun(IntPtr phandle, string pfilename);

        /*************************************************************
        ˵�������ص�ram������
        ���룺������phandle �ڴ�buff
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownMemProgramToRamAndRun")]
        public static extern Int32 SMCDownMemProgramToRamAndRun(IntPtr phandle, string pbuffer,Int32 buffsize);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCDownMemProgramToRamAndRun(SMCHANDLE handle, string pbuffer, uint32 buffsize);


        /*************************************************************
        ˵�����ϴ������ļ�
        ���룺������phandle �ڴ�buff
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCUpProgram")]
        public static extern Int32 SMCUpProgram(IntPtr phandle, string pfilename, string pfilenameinControl);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCUpProgram(SMCHANDLE handle, string pfilename, string pfilenameinControl);

        /*************************************************************
        ˵�����ϴ������ļ�
        ���룺������phandle �ڴ�buff
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCUpProgramToMem")]
        public static extern Int32 SMCUpProgramToMem(IntPtr phandle, ref Byte pbuffer, Int32 buffsize, string pfilenameinControl, ref Int32 puifilesize);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCUpProgramToMem(SMCHANDLE handle, char* pbuffer, uint32 buffsize, char* pfilenameinControl, uint32* puifilesize);


        /*************************************************************
        ˵������ͣ
        ���룺������phandle �ļ����� ��ΪNULL��ʱ������ȱʡ�ļ�
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCPause")]
         public static extern Int32 SMCPause(IntPtr phandle);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCPause(SMCHANDLE handle);

        /*************************************************************
        ˵����ֹͣ
        ���룺������phandle �ļ����� ��ΪNULL��ʱ������ȱʡ�ļ�
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCStop")]
        public static extern Int32 SMCStop(IntPtr phandle);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCStop(SMCHANDLE handle);

        /*************************************************************
        ˵����������ʱ�ļ�
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCRunTempFile")]
        public static extern  Int32 SMCRunTempFile(IntPtr phandle);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCRunTempFile(SMCHANDLE handle);

        /*************************************************************
        ˵������ȡʣ��ռ�
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCCheckRemainProgramSpace")]
        public static extern Int32 SMCCheckRemainProgramSpace(IntPtr phandle, ref Int32 pRemainSpaceInKB);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCCheckRemainProgramSpace(SMCHANDLE handle, uint32 * pRemainSpaceInKB);


        /*************************************************************
        ˵������ȡ����ֹͣԭ��
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCCheckProgramStopReason")]
        public static extern Int32 SMCCheckProgramStopReason(IntPtr phandle, ref Int32 pStopReason);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCCheckProgramStopReason(SMCHANDLE handle, uint32 * pStopReason);

        /*************************************************************
        ˵������ȡ����ǰ��
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetCurRunningLine")]
        public static extern Int32 SMCGetCurRunningLine(IntPtr phandle, ref Int32 pLineNum);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCGetCurRunningLine(SMCHANDLE handle, uint32 * pLineNum);


        /*************************************************************
        ˵�������õ������У����ʵʱ�޸�״̬��������ʧ
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetStepRun")]
        public static extern Int32 SMCSetStepRun(IntPtr phandle, Byte bifStep);
       // [DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCSetStepRun(SMCHANDLE handle, Byte bifStep);


        /*************************************************************
        ˵�������ÿ��ߣ����ʵʱ�޸�״̬��������ʧ
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetRunNoIO")]
        public static extern Int32 SMCSetRunNoIO(IntPtr phandle, Byte bifVainRun);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCSetRunNoIO(SMCHANDLE handle, Byte bifVainRun);

        /*************************************************************
        ˵������ȡ����
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetRunningOption")]
        public static extern Int32 SMCGetRunningOption(IntPtr phandle, ref Byte bifStep, ref Byte bifVainRun);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCGetRunningOption(SMCHANDLE handle, ref Byte bifStep, ref Byte bifVainRun);



        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCContinueRun")]
        public static extern Int32 SMCContinueRun(IntPtr phandle);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCContinueRun(SMCHANDLE handle);


        /*************************************************************
        ˵��������ļ��Ƿ����
        ���룺������phandle ���������ļ�����������չ
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCCheckProgramFile")]
        public static extern Int32 SMCCheckProgramFile(IntPtr phandle, string pfilenameinControl, ref Byte pbIfExist, ref Int32 pFileSize);
        //[DllImport("smc6x.dll", EntryPoint = "")]
        //public static extern Int32 SMCCheckProgramFile(IntPtr phandle, string pfilenameinControl, ref Byte pbIfExist, ref Int32 pFileSize);


        /*************************************************************
        ˵�������ҿ������ϵ��ļ��� �ļ���Ϊ�ձ�ʾ�ļ���������
        ���룺������phandle ���������ļ�����������չ
        ����� �Ƿ���� �ļ���С
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCFindFirstProgramFile")]
        public static extern Int32 SMCFindFirstProgramFile(IntPtr phandle, ref Byte pfilenameinControl, ref Int32 pFileSize);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCFindFirstProgramFile(SMCHANDLE handle, char* pfilenameinControl, uint32 *pFileSize);


        /*************************************************************
        ˵�������ҿ������ϵ��ļ��� �ļ���Ϊ�ձ�ʾ�ļ���������
        ���룺������phandle ���������ļ�����������չ
        ����� �Ƿ���� �ļ���С
        ����ֵ��������
        *************************************************************/
       [DllImport("smc6x.dll", EntryPoint = "SMCFindNextProgramFile")]
        public static extern  Int32 SMCFindNextProgramFile(IntPtr phandle, ref Byte pfilenameinControl, ref Int32 pFileSize);

        /*************************************************************
        ˵�������ҿ������ϵĵ�ǰ�ļ�
        ���룺������phandle ���������ļ�����������չ
        ����� �Ƿ���� �ļ���С(��ʱ��֧��)
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetCurProgramFile")]
        public static extern  Int32 SMCGetCurProgramFile(IntPtr phandle, ref Byte pfilenameinControl, ref Int32 pFileSize);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCGetCurProgramFile(SMCHANDLE handle, char* pfilenameinControl, uint32 *pFileSize);


        /*************************************************************
        ˵����ɾ���������ϵ��ļ�
        ���룺������phandle ���������ļ�����������չ
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDeleteProgramFile")]
        public static extern Int32 SMCDeleteProgramFile(IntPtr phandle, string pfilenameinControl);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCDeleteProgramFile(SMCHANDLE handle, string pfilenameinControl);

        /*************************************************************
        ˵����ɾ���������ϵ��ļ�
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCRemoveAllProgramFiles")]
        public static extern  Int32 SMCRemoveAllProgramFiles(IntPtr phandle);
   

        /***********************  ���ò���  ************************/


        /*************************************************************
        ˵����ͨ�õ��ַ����ӿ�
        ���룺������phandle �����ַ����������ַ����� �����ַ�������, ������ҪӦ��ʱ����uiResponseLength = 0
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCCommand")]
        public static extern  Int32 SMCCommand(IntPtr phandle, string pszCommand, ref Byte psResponse, Int32 uiResponseLength);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCCommand(SMCHANDLE handle, string pszCommand, char* psResponse, uint32 uiResponseLength);

        /*************************************************************
        ˵������ǰ���ô���
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCBurnSetting")]
        public static extern  Int32 SMCBurnSetting(IntPtr phandle);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCBurnSetting(SMCHANDLE handle);


        /*************************************************************
        ˵�������������ļ�
        ���룺������phandle �ļ���
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownSetting")]
        public static extern  Int32 SMCDownSetting(IntPtr phandle, string pfilename);

        /*************************************************************
        ˵�������������ļ�
        ���룺������phandle buff 
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownMemSetting")]
        public static extern  Int32 SMCDownMemSetting(IntPtr phandle, string pbuffer, Int32 buffsize);

        /*************************************************************
        ˵�����ϴ�����
        ���룺������phandle �ڴ�buff
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCUpSetting")]
        public static extern  Int32 SMCUpSetting(IntPtr phandle, string pfilename);
        /*************************************************************
        ˵�����ϴ�����
        ���룺������phandle �ڴ�buff ����ʵ�ʵ��ļ�����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCUpSettingToMem")]
        public static extern  Int32 SMCUpSettingToMem(IntPtr phandle, ref Byte pbuffer, Int32 buffsize,  ref Int32 puifilesize);


        /*************************************************************
        ˵�������������ļ�
        ���룺������phandle �ļ���
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownDefaultSetting")]
        public static extern  Int32 SMCDownDefaultSetting(IntPtr phandle, string pfilename);
        /*************************************************************
        ˵�������������ļ�, �ı��ļ��ĳ�����strlen ����
        ���룺������phandle buff 
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownMemDefaultSetting")]
        public static extern  Int32 SMCDownMemDefaultSetting(IntPtr phandle, string pbuffer, Int32 buffsize);

        /*************************************************************
        ˵�����ϴ�����
        ���룺������phandle �ڴ�buff
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCUpDefaultSetting")]
        public static extern  Int32 SMCUpDefaultSetting(IntPtr phandle, string pfilename);

        /*************************************************************
        ˵�����ϴ�����
        ���룺������phandle �ڴ�buff
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCUpDefaultSettingToMem")]
        public static extern  Int32 SMCUpDefaultSettingToMem(IntPtr phandle, ref Byte pbuffer, Int32 buffsize, ref Int32 puifilesize);

        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetIpAddr")]
        public static extern  Int32 SMCSetIpAddr(IntPtr phandle, string sIpAddr, string sGateAddr, string sMask, Byte bifdhcp);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCGetIpAddr(SMCHANDLE handle, char* sIpAddr, char* sGateAddr, char* sMask, ref Byte  pbifdhcp);


        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetIpAddr")]
        public static extern  Int32 SMCGetIpAddr(IntPtr phandle, ref Byte sIpAddr, ref Byte sGateAddr, ref Byte sMask, ref Byte pbifdhcp);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCGetIpAddr(SMCHANDLE handle, char* sIpAddr, char* sGateAddr, char* sMask, ref Byte  pbifdhcp);

        /*************************************************************
        ˵������ȡ��ǰ��������IP��ַ, ע��:������dhcp�Ժ����õ�IP��ʵ�ʵĲ�һ�¡�
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetCurIpAddr")]
        public static extern  Int32 SMCGetCurIpAddr(IntPtr phandle, ref Byte sIpAddr);

        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetZeroSpeed")]
        public static extern  Int32 SMCSetZeroSpeed(IntPtr phandle, Byte iaxis, Int32 uiSpeed);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCSetZeroSpeed(SMCHANDLE handle, Byte iaxis, uint32 uiSpeed);


        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetZeroSpeed")]
        public static extern  Int32 SMCGetZeroSpeed(IntPtr phandle, Byte iaxis, ref Int32 puiSpeed);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCGetZeroSpeed(SMCHANDLE handle, Byte iaxis, uint32* puiSpeed);


        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetLocateSpeed")]
        public static extern  Int32 SMCSetLocateSpeed(IntPtr phandle, Byte iaxis, Int32 uiSpeed);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCSetLocateSpeed(SMCHANDLE handle, Byte iaxis, uint32 uiSpeed);


        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetLocateSpeed")]
        public static extern Int32 SMCGetLocateSpeed(IntPtr phandle, Byte iaxis, ref Int32 puiSpeed);

        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetLocateStartSpeed")]
        public static extern Int32 SMCSetLocateStartSpeed(IntPtr phandle, Byte iaxis, Int32 uiSpeed);

        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetLocateStartSpeed")]
        public static extern Int32 SMCGetLocateStartSpeed(IntPtr phandle, Byte iaxis, ref Int32 puiSpeed);


        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetLocateAcceleration")]
        public static extern Int32 SMCSetLocateAcceleration(IntPtr phandle, Byte iaxis, Int32 uiValue);

        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetLocateAcceleration")]
        public static extern  Int32 SMCGetLocateAcceleration(IntPtr phandle, Byte iaxis, ref Int32 puiValue);

        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetLocateDeceleration")]
        public static extern Int32 SMCSetLocateDeceleration(IntPtr phandle, Byte iaxis, Int32 uiValue);
        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetLocateDeceleration")]
        public static extern Int32 SMCGetLocateDeceleration(IntPtr phandle, Byte iaxis, ref Int32 puiValue);

        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetUnitPulses")]
        public static extern Int32 SMCSetUnitPulses(IntPtr phandle, Byte iaxis, Int32 uiValue);

        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetUnitPulses")]
        public static extern  Int32 SMCGetUnitPulses(IntPtr phandle, Byte iaxis, ref Int32 puiValue);


        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetVectStartSpeed")]
        public static extern Int32 SMCSetVectStartSpeed(IntPtr phandle, Int32 uiValue);
        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetVectStartSpeed")]
        public static extern Int32 SMCGetVectStartSpeed(IntPtr phandle, ref Int32 puiValue);

        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetVectSpeed")]
        public static extern  Int32 SMCSetVectSpeed(IntPtr phandle, Int32 uiValue);

        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetVectSpeed")]
        public static extern  Int32 SMCGetVectSpeed(IntPtr phandle, ref Int32 puiValue);

        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetVectAcceleration")]
        public static extern Int32 SMCSetVectAcceleration(IntPtr phandle, Int32 uiValue);

        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetVectAcceleration")]
        public static extern Int32 SMCGetVectAcceleration(IntPtr phandle, ref Int32 puiValue);


        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetVectDeceleration")]
        public static extern Int32 SMCSetVectDeceleration(IntPtr phandle, Int32 uiValue);

        /*************************************************************
        ˵������������
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetVectDeceleration")]
        public static extern Int32 SMCGetVectDeceleration(IntPtr phandle, ref Int32 puiValue);



        /***********************  �˶�����  ************************/
 
        /*************************************************************
        ˵����
        ���룺������phandle ��ţ� ���ȣ� �Ƿ�����ƶ�
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCPMove")]
        public static extern Int32 SMCPMove(IntPtr phandle, Byte iaxis, double dlength, Byte bIfAbs);

        /*************************************************************
        ˵����
        ���룺������phandle ��ţ� ���ȣ� �Ƿ�����ƶ�
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCPMovePluses")]
        public static extern Int32 SMCPMovePluses(IntPtr phandle, Byte iaxis, Int32 ilength, Byte bIfAbs);

        /*************************************************************
        ˵����
        ���룺������phandle ��ţ� ����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVMove")]
        public static extern Int32 SMCVMove(IntPtr phandle, Byte iaxis, Byte bIfPositiveDir);


        /*************************************************************
        ˵����
        ���룺������phandle ��ţ� ����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCPMoveList")]
        public static extern Int32 SMCPMoveList(IntPtr phandle,Byte itotalaxises,  ref Byte puilineaxislist, Int32 uisteps, ref double pDistanceList, Byte bIfAbs);



        /*************************************************************
        ˵����
        ���룺������phandle ��ţ� ����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCCheckDown")]
        public static extern Int32 SMCCheckDown(IntPtr phandle,Byte iaxis,  ref Byte pbIfDown);

        /*************************************************************
        ˵�������㣬����ģʽͨ������ָ��
        ���룺������phandle ��ţ� ����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCHomeMove")]
        public static extern Int32 SMCHomeMove(IntPtr phandle,Byte iaxis);

        /*************************************************************
        ˵����
        ���룺������phandle ���
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCIfHomeMoveing")]
        public static extern Int32 SMCIfHomeMoveing(IntPtr phandle,Byte iaxis, ref Byte pbIfHoming);

        /*************************************************************
        ˵����
        ���룺������phandle ���
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDecelStop")]
        public static extern Int32 SMCDecelStop(IntPtr phandle,Byte iaxis);

        /*************************************************************
        ˵����
        ���룺������phandle ���
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCImdStop")]
        public static extern Int32 SMCImdStop(IntPtr phandle,Byte iaxis);


        /*************************************************************
        ˵����
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCEmgStop")]
        public static extern Int32 SMCEmgStop(IntPtr phandle);

        /*************************************************************
        ˵�������ٶ�
        ���룺������phandle ���
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCChangeSpeed")]
        public static extern Int32 SMCChangeSpeed(IntPtr phandle,Byte iaxis, double dspeed);


        /*************************************************************
        ˵����
        ���룺������phandle ���
        ���������
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetPosition")]
        public static extern Int32 SMCGetPosition(IntPtr phandle,Byte iaxis, ref double pposition);


        /*************************************************************
        ˵���� ��ȡ��ǰ�Ĺ�������
        ���룺������phandle ���
        ���������
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetWorkPosition")]
        public static extern Int32 SMCGetWorkPosition(IntPtr phandle,Byte iaxis, ref double pposition);

        /*************************************************************
        ˵���� ��ȡ��е���꣬���巽ʽ
        ���룺������phandle ���
        ���������
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetPositionPulses")]
        public static extern Int32 SMCGetPositionPulses(IntPtr phandle,Byte iaxis, ref Int32 pposition);

        /*************************************************************
        ˵���� ��ȡ�������
        ���룺������phandle ���
        ���������
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetWorkOriginPosition")]
        public static extern Int32 SMCGetWorkOriginPosition(IntPtr phandle, Byte iaxis, ref double pposition);

        /*************************************************************
        ˵����
        ���룺������phandle ��� ����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetPosition")]
        public static extern Int32 SMCSetPosition(IntPtr phandle,Byte iaxis, double dposition);
        /*************************************************************
        ˵����
        ���룺������phandle ��� ����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetPositionPulses")]
        public static extern Int32 SMCSetPositionPulses(IntPtr phandle,Byte iaxis, Int32 iposition);

        /*************************************************************
        ˵����
        ���룺������phandle ���
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWaitDown")]
        public static extern Int32 SMCWaitDown(IntPtr phandle,Byte iaxis);

        /*************************************************************
        ˵����
        ���룺������phandle ���
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWaitPoint")]
        public static extern Int32 SMCWaitPoint(IntPtr phandle,Byte iaxis, double dpos);

        /*************************************************************
        ˵����
        ���룺������phandle ���
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCHandWheelSet")]
        public static extern Int32 SMCHandWheelSet(IntPtr phandle,Byte iaxis, Int32 imulti, Byte bifDirReverse);
        /*************************************************************
        ˵����
        ���룺������phandle ���
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCHandWheelMove")]
        public static extern Int32 SMCHandWheelMove(IntPtr phandle,Byte iaxis, Byte bifenable);


        /*************************************************************
        ˵����
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveStart")]
        public static extern Int32 SMCVectMoveStart(IntPtr phandle);

        /*************************************************************
        ˵����
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveEnd")]
        public static extern Int32 SMCVectMoveEnd(IntPtr phandle);


        /*************************************************************
        ˵����
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetVectMoveState")]
        public static extern Int32 SMCGetVectMoveState(IntPtr phandle, ref Byte pState);

        /*************************************************************
        ˵����
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/

        [DllImport("smc6x.dll", EntryPoint = "SMCGetVectMoveRemainSpace")]
        public static extern Int32 SMCGetVectMoveRemainSpace(IntPtr phandle, ref Int32 pSpace);

        /*************************************************************
        ˵�����岹�����޸��ٶ�����
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveLine1")]
        public static extern Int32 SMCVectMoveLine1(IntPtr phandle, Byte iaxis, double Distance, double dspeed, Byte bIfAbs);
        /*************************************************************
        ˵�����岹�����޸��ٶ�����
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveLine2")]
        public static extern Int32 SMCVectMoveLine2(IntPtr phandle, Byte iaxis1, double Distance1, Byte iaxis2, double Distance2, double dspeed, Byte bIfAbs);

        /*************************************************************
        ˵�����岹�������޸��ٶ�����
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveLineN")]
        public static extern Int32 SMCVectMoveLineN(IntPtr phandle, Byte itotalaxis, ref Byte piaxisList, ref double DistanceList, double dspeed, Byte bIfAbs);

        /*************************************************************
        ˵�����岹�����޸��ٶ�����
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveMultiLine2")]
        public static extern Int32 SMCVectMoveMultiLine2(IntPtr phandle, Byte iaxis1, Byte iaxis2, Int32 uiSectes, ref double DistanceList, ref double dspeedList, Byte bIfAbs);

        /*************************************************************
        ˵�����岹�������޸��ٶ�����
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveMultiLineN")] 
        public static extern Int32 SMCVectMoveMultiLineN(IntPtr phandle, Byte itotalaxis, ref Byte piaxisList, Int32 uiSectes,ref double DistanceList, ref double dspeedList, Byte bIfAbs);

        /*************************************************************
        ˵�����岹�����޸��ٶ�����
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveArc")] 
        public static extern Int32 SMCVectMoveArc(IntPtr phandle, Byte iaxis1, Byte iaxis2, double Distance1, double Distance2, double Center1, double Center2, Byte bIfAnticlockwise, double dspeed, Byte bIfAbs);


        /*************************************************************
        ˵�������ٵ����
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveSetSpeedLimition")] 
        public static extern Int32 SMCVectMoveSetSpeedLimition(IntPtr phandle, double dspeed);


        /*************************************************************
        ˵����
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWaitVectLength")] 
        public static extern Int32 SMCWaitVectLength(IntPtr phandle, double vectlength);

        /*************************************************************
        ˵����
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetCurRunVectLength")] 
        public static extern Int32 SMCGetCurRunVectLength(IntPtr phandle, ref double pvectlength);
        /*************************************************************
        ˵����
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetCurSpeed")] 
        public static extern Int32 SMCGetCurSpeed(IntPtr phandle, Byte iaxis, ref double pspeed);

        /*************************************************************
        ˵���� ������ͣ, �岹��ͣ����Ȼ���Լ���С��
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMovePause")]
        public static extern Int32 SMCVectMovePause(IntPtr phandle);

        /*************************************************************
        ˵���� �岹����ֹͣ
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveStop")] 
        public static extern Int32 SMCVectMoveStop(IntPtr phandle);


        /*************************************************************
        ˵������ͣ; ������������ݲ�֧��
        ���룺������phandle
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCAxisPause")] 
        public static extern Int32 SMCAxisPause(IntPtr phandle, Byte iaxis);

        /***********************  IO�Ƚӿڲ���  ************************/

        /*************************************************************
        ˵��������LED���������
        ���룺������phandle led��ţ���1��ʼ
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWriteLed")] 
        public static extern Int32 SMCWriteLed(IntPtr phandle, Int32 iLedNum, Byte bifLighten);


        /*************************************************************
        ˵����д�����
        ���룺������phandle io��ţ���1��ʼ 0-�͵�ƽ�� 1- �ߵ�ƽ
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWriteOutBit")] 
        public static extern Int32 SMCWriteOutBit(IntPtr phandle, Int32 ioNum, Byte IoState);

        /*************************************************************
        ˵�����������
        ���룺������phandle io��ţ���1��ʼ
        �����0-�͵�ƽ�� 1- �ߵ�ƽ
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadInBit")] 
        public static extern Int32 SMCReadInBit(IntPtr phandle, Int32 ioNum, ref Byte pIoState);

        /*************************************************************
        ˵�����������
        ���룺������phandle io��ţ���1��ʼ
        �����0-�͵�ƽ�� 1- �ߵ�ƽ
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadOutBit")] 
        public static extern Int32 SMCReadOutBit(IntPtr phandle, Int32 ioNum, ref Byte pIoState);

        /*************************************************************
        ˵����дȫ�������
        ���룺������phandle 
              IoMask: 1��λҪ�޸ģ�����ͨ����������޸�ָ������IO
              IoState:  0-�͵�ƽ�� 1- �ߵ�ƽ;  0-31λ ���� 1-32IO
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWriteOutPort")] 
        public static extern Int32 SMCWriteOutPort(IntPtr phandle, Int32 IoMask, Int32 IoState);

        /*************************************************************
        ˵������ȫ�������
        ���룺������phandle 
        �����0-�͵�ƽ�� 1- �ߵ�ƽ
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadInPort")]
        public static extern Int32 SMCReadInPort(IntPtr phandle, ref Int32 pIoState);

        /*************************************************************
        ˵������ȫ�������
        ���룺������phandle 
        �����0-�͵�ƽ�� 1- �ߵ�ƽ
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadOutPort")] 
        public static extern Int32 SMCReadOutPort(IntPtr phandle, ref Int32 pIoState);


        /*************************************************************
        ˵�������ŷ��澯����״̬ 6200û��
        ���룺������phandle io��ţ���1��ʼ
        �����0-��Ч�� 1- ��Ч
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadAlarmState")] 
        public static extern Int32 SMCReadAlarmState(IntPtr phandle, Byte iaxis, ref Byte pIoState);

        /*************************************************************
        ˵������ԭ������״̬
        ���룺������phandle io��ţ���1��ʼ
        �����0-��Ч�� 1- ��Ч
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadHomeState")] 
        public static extern Int32 SMCReadHomeState(IntPtr phandle, Byte iaxis, ref Byte pIoState);


        /*************************************************************
        ˵��������ͣ����״̬
        ���룺������phandle
        �����0-��Ч�� 1- ��Ч
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadEMGState")]
        public static extern Int32 SMCReadEMGState(IntPtr phandle, ref Byte pIoState);
        /*************************************************************
        ˵����������AB����״̬, 6200������Ϊ9 10��������޹� 
        ���룺������phandle
        �����0-��Ч�� 1- ��Ч
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadHandWheelStates")]
        public static extern Int32 SMCReadHandWheelStates(IntPtr phandle, Byte iaxis, ref Byte pIoAState, ref Byte pIoBState);

        /*************************************************************
        ˵��������λ״̬
        ���룺������phandle
        �����0-��Ч�� 1- ��Ч
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadElStates")]
        public static extern Int32 SMCReadElStates(IntPtr phandle, Byte iaxis, ref Byte pElDecState, ref Byte pElPlusState);


        /*************************************************************
        ˵�����������ź�����״̬
        ���룺������phandle io��ţ���1��ʼ
        �����0-��Ч�� 1- ��Ч
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadSdStates")]
        public static extern Int32 SMCReadSdStates(IntPtr phandle, Byte iaxis, ref Byte pIoState);

        /*************************************************************
        ˵��������λ�ź�����״̬
        ���룺������phandle io��ţ���1��ʼ
        �����0-��Ч�� 1- ��Ч
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadInpStates")]
        public static extern Int32 SMCReadInpStates(IntPtr phandle, Byte iaxis, ref Byte pIoState);

        /*************************************************************
        ˵����дPWMռ�ձ�
        ���룺������phandle ͨ��:1/2
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWritePwmDuty")]
        public static extern Int32 SMCWritePwmDuty(IntPtr phandle, Byte ichannel, float fDuty);
        /*************************************************************
        ˵����дPWMƵ��
        ���룺������phandle ͨ��:1/2
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWritePwmFreqency")]
        public static extern Int32 SMCWritePwmFreqency(IntPtr phandle, Byte ichannel, float fFre);

        /*************************************************************
        ˵����дDA�����ѹ
        ���룺������phandle ͨ��:1/2
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWriteDaOut")]
        public static extern Int32 SMCWriteDaOut(IntPtr phandle, Byte ichannel, float fLevel);

        /*************************************************************
        ˵����PWMռ�ձ�
        ���룺������phandle ͨ��:1/2
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadPwmDuty")]
        public static extern Int32 SMCReadPwmDuty(IntPtr phandle, Byte ichannel, ref float fDuty);

        /*************************************************************
        ˵����PWMƵ��
        ���룺������phandle ͨ��:1/2
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadPwmFreqency")]
        public static extern Int32 SMCReadPwmFreqency(IntPtr phandle, Byte ichannel, ref float fFre);

        /*************************************************************
        ˵����DA�����ѹ
        ���룺������phandle ͨ��:1/2
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadDaOut")]
        public static extern Int32 SMCReadDaOut(IntPtr phandle, Byte ichannel, ref float fLevel);


        /*************************************************************
        ˵�����ͻ����, �������ֻ�Բ��ֿͻ�����
        ���룺������phandle
        �����״̬
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetClientId")]
       public static extern Int32 SMCGetClientId(IntPtr phandle,ref Int32 pId);

        /*************************************************************
        ˵���������Ʒ����
        ���룺������phandle
        �����״̬
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetSoftwareId")]
        public static extern Int32 SMCGetSoftwareId(IntPtr phandle,ref Int32 pId);


        /*************************************************************
        ˵����Ӳ�����
        ���룺������phandle
        �����״̬
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetHardwareId")]
        public static extern Int32 SMCGetHardwareId(IntPtr phandle,ref Int32 pId);


        /*************************************************************
        ˵��������汾�ţ������ڱ�ʶ
        ���룺������phandle
        �����״̬
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetSoftwareVersion")]
        public static extern Int32 SMCGetSoftwareVersion(IntPtr phandle,ref Int32 pVersion);

        /*************************************************************
        ˵�����ϴ������ļ�
        ���룺������phandle �ڴ�buff
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCUpPasswordFile")] 
        public static extern Int32 SMCUpPasswordFile(IntPtr phandle, string pfilename);

        /*************************************************************
        ˵�����ϴ������ļ�
        ���룺������phandle �ڴ�buff ����ʵ�ʵ��ļ�����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCUpPasswordFileToMem")] 
        public static extern Int32 SMCUpPasswordFileToMem(IntPtr phandle, ref Byte pbuffer, Int32 buffsize, ref Int32 puifilesize);

        /*************************************************************
        ˵�������������ļ�
        ���룺������phandle �ļ���
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownPasswordFile")] 
         public static extern Int32 SMCDownPasswordFile(IntPtr phandle, string pfilename);


        /*************************************************************
        ˵�������������ļ�, �ı��ļ��ĳ�����strlen ����
        ���룺������phandle buff 
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownMemPasswordFile")]
         public static extern Int32 SMCDownMemPasswordFile(IntPtr phandle, string pbuffer, Int32 buffsize);


        /*************************************************************
        ˵������������
        ���룺������phandle ����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCEnterSetPassword")] 
         public static extern Int32 SMCEnterSetPassword(IntPtr phandle, Int32 uipassword);

        /*************************************************************
        ˵������������
        ���룺������phandle ����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCEnterEditPassword")] 
         public static extern Int32 SMCEnterEditPassword(IntPtr phandle, Int32 uipassword);


        /*************************************************************
        ˵������������
        ���룺������phandle ����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCEnterSuperPassword")] 
         public static extern Int32 SMCEnterSuperPassword(IntPtr phandle, Int32 uipassword);

        /*************************************************************
        ˵������������
        ���룺������phandle ����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCEnterTimePassword")]
         public static extern Int32 SMCEnterTimePassword(IntPtr phandle, Int32 uipassword);


        /*************************************************************
        ˵��������Ѿ����������, �����ٴ�����������ܽ�����Ӧ����
        ���룺������phandle ����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCClearEnteredPassword")]
         public static extern Int32 SMCClearEnteredPassword(IntPtr phandle);

        /*************************************************************
        ˵�����޸�����
        ���룺������phandle ����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCModifySetPassword")] 
         public static extern Int32 SMCModifySetPassword(IntPtr phandle, Int32 uipassword);

        /*************************************************************
        ˵�����޸�����
        ���룺������phandle ����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCModifyEditPassword")] 
        public static extern Int32 SMCModifyEditPassword(IntPtr phandle, Int32 uipassword);

        /*************************************************************
        ˵�����޸�����
        ���룺������phandle ����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCModifySuperPassword")]
         public static extern Int32 SMCModifySuperPassword(IntPtr phandle, Int32 uipassword);
        /*************************************************************
        ˵������ȡ�û��������
        ���룺������phandle ����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetTrialCondition")] 
         public static extern Int32 SMCGetTrialCondition(IntPtr phandle, ref Int32 pRunHours, ref Int32 pbifTimeLocked, ref Int32 pAlreadyEnterdTimePasswordNum);



        /*************************************************************
        ˵����modbus�Ĵ�������
        ���룺������phandle �Ĵ�����ַ
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCModbus_Set0x")] 
        public static extern Int32 SMCModbus_Set0x(IntPtr phandle, Int32 start, Int32 inum, ref Byte pdata);

        [DllImport("smc6x.dll", EntryPoint = "SMCModbus_Get0x")] 
        public static extern Int32 SMCModbus_Get0x(IntPtr phandle, Int32 start, Int32 inum, ref Byte pdata);

        [DllImport("smc6x.dll", EntryPoint = "SMCModbus_Get4x")] 
        public static extern Int32 SMCModbus_Get4x(IntPtr phandle, Int32 start, Int32 inum, ref Int32 pdata);

        [DllImport("smc6x.dll", EntryPoint = "SMCModbus_Set4x")]
        public static extern Int32 SMCModbus_Set4x(IntPtr phandle, Int32 start, Int32 inum, ref Int32 pdata);



        /*************************************************************
        ˵�����������﷨
        ���룺�����ַ������棬����1024�ֽ�
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCCheckProgramSyntax")] 
        public static extern Int32 SMCCheckProgramSyntax(string sin, ref Byte sError);

        [DllImport("smc6x.dll", EntryPoint = "SMC_MultiLine")]
        public static extern Int32 SMC_MultiLine(IntPtr phandle,Byte itotalaxis, ref Byte piaxisList, Int32 uiSectes, ref double DistanceList, ref double dspeedList, Byte bIfAbs);


        /*ADD*/
        /*************************************************************
        ˵���� ����S���߱���
        ���룺axis ���
	           para ���߱���
        �������
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCLineScureSet")] 
        public static extern Int32 SMCLineScureSet(IntPtr phandle,Byte axis,double para);

        /*************************************************************
        ˵�������ù������
        ���룺������phandle ���0-3 ����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetWorkOriginPosition")] 
        public static extern Int32 SMCSetWorkOriginPosition(IntPtr phandle, Byte iaxis, double dposition);


        /*************************************************************
        ���ܣ�����/��ȡ�����λ��ʹ��, ��λ��ֵ, ��Ӧ����
        ������axis ָ�����
	          ON_OFF ����λʹ�ܣ� 0 �C��ֹ�� 1 �Cʹ��
              SL_action ��λ������ 0 �C��ͣ�� 1 �C����ͣ
              N_limit ����λֵ
              P_limit ����λֵ
        ����ֵ���������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCConfigSoftlimit")]
        public static extern Int32 SMCConfigSoftlimit(IntPtr phandle, Byte axis, Byte ON_OFF,Byte SL_action,float N_limit,float Plimit);


        /*************************************************************
        ���ܣ�����/��ȡ�����λ��ʹ��, ��λ��ֵ, ��Ӧ����
        ������axis ָ�����
	          ON_OFF ����λʹ�ܣ� 0 �C��ֹ�� 1 �Cʹ��
              SL_action ��λ������ 0 �C��ͣ�� 1 �C����ͣ
              N_limit ����λֵ
              P_limit ����λֵ
        ����ֵ���������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetConfigSoftlimit")]
        public static extern Int32 SMCGetConfigSoftlimit(IntPtr phandle, Byte axis, ref Byte ON_OFF, ref Byte SL_action, ref float N_limit, ref float Plimit);
        /*************************************************************
        ���ܣ�����/��ȡ��϶����ֵ
        ������axis ָ�����
        backlash ��϶����ֵ�� ��λ������
        ����ֵ���������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetBackLash")]
        public static extern Int32 SMCSetBackLash(IntPtr phandle, Byte axis, Int32 lash );
        /*************************************************************
        ���ܣ�����/��ȡ��϶����ֵ
        ������axis ָ�����
        backlash ��϶����ֵ�� ��λ������
        ����ֵ���������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetBackLash")]
        public static extern Int32 SMCGetBackLash(IntPtr phandle, Byte axis, ref Int32 lash );


        /**************************************************************
        ���ܣ����ֲ�ͬ�Ļ�ԭ��ģʽ��ʵ�־�ȷ��λ��ԭ��ķ�����ͨ�����ô˺��������ѡ������һ��ģʽ��
        ������axis����ţ�
        home_dir ���㷽��1��������2��������
        vel �����ٶ�
        mode ��ԭ����ź�ģʽ
        1 �C һ�λ���
        2 �C ���λ���
        3 �C һ�λ���ӻ���
        ����ֵ���������
        **********************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCConfigHomeMode")] 
        public static extern Int32 SMCConfigHomeMode(IntPtr phandle, Byte axis,Byte home_dir,double vel,Byte mode);

        /*************************************************************
        ˵������ȡ��������λ��
        ���룺���Ӿ����handle����ţ�0-3��0xFF
        �������������λ��
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetEncodePosition")] 
        public static extern  Int32 SMCGetEncodePosition(IntPtr phandle, Byte iaxis, ref Int32 pposition);

        /*************************************************************
        ˵�������ñ�������λ��
        ���룺���Ӿ����handle����ţ�0-3
        �������������λ��
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetEncodePosition")]
        public static extern  Int32 SMCSetEncodePosition(IntPtr phandle, Byte iaxis, Int32 pposition);

        /*************************************************************
        ˵������ȡ����������λ��
        ���룺���Ӿ����handle����ţ�0-3��0xFF
        ���������������λ��
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetEncodeLatchPosition")]
        public static extern  Int32 SMCGetEncodeLatchPosition(IntPtr phandle, Byte iaxis, ref Int32 pposition);

        /*************************************************************
        ˵������ȡ�����������־
        ���룺���Ӿ����handle����ţ�0-3
        ����������������־
        ����ֵ��������
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCGetEncodeLatchFlag")]
        public static extern  Int32 SMCGetEncodeLatchFlag(IntPtr phandle, Byte iaxis, ref Byte pflag);

        /*************************************************************
        ˵������ȡ������EZ�ź�״̬
        ���룺���Ӿ����handle����ţ�0-3
        �����������EZ�ź�״̬��0-��Ч��1��Ч
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetEncodeEZState")]
        public static extern  Int32 SMCGetEncodeEZState(IntPtr phandle, Byte iaxis, ref Byte pstate);

        /*************************************************************
        ˵������ȡ������LTC�ź�״̬
        ���룺���Ӿ����handle����ţ�0-3
        �����������LTC�ź�״̬��0-��Ч��1��Ч
        ����ֵ��������
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCGetEncodeLatchState")]
        public static extern  Int32 SMCGetEncodeLatchState(IntPtr phandle, Byte iaxis, ref Byte pState);

        /*************************************************************
        ˵������������������־
        ���룺���Ӿ����handle����ţ�0-3
        �������
        ����ֵ��������
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCClearEncodeLatchFlag")]
        public static extern  Int32 SMCClearEncodeLatchFlag(IntPtr phandle, Byte iaxis);

        /*************************************************************
        ˵������ȡ������Z�źű�־
        ���룺���Ӿ����handle����ţ�0-3
        �����������Z�źű�־
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetEncodeEzFlag")]
        public static extern  Int32 SMCGetEncodeEzFlag(IntPtr phandle, Byte iaxis, ref Byte pflag);

        /*************************************************************
        ˵�������������Z�źű�־
        ���룺���Ӿ����handle����ţ�0-3
        �������
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCResetClearFlag")]
        public static extern  Int32 SMCResetClearFlag(IntPtr phandle, Byte iaxis);

        /*************************************************************
        ˵������ȡ������������־
        ���룺���Ӿ����handle����ţ�0-3
        �����������������־
        ����ֵ��������
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCGetEncodeCountFlag")]
         public static extern  Int32 SMCGetEncodeCountFlag(IntPtr phandle, Byte iaxis, ref Byte pflag);

        /*************************************************************
        ˵�������������������־
        ���룺���Ӿ����handle����ţ�0-3
        �������
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCResetEncodeCountFlag")]
        public static extern  Int32 SMCResetEncodeCountFlag(IntPtr phandle, Byte iaxis);

        /*************************************************************
        ˵�������ֽڶ�ȡ����
        ���룺���Ӿ����handle��д�����ݣ�pData����ַ��addr
        �������ȡ����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadFramUint8")]
        public static extern Int32 SMCReadFramUint8(IntPtr phandle, Int32 addr, ref Byte pData);

        /*************************************************************
        ˵�������ֽ�д����
        ���룺���Ӿ����handle��д�����ݣ�pData����ַ��addr
        �������ȡ����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWriteFramUint8")]
        public static extern  Int32 SMCWriteFramUint8(IntPtr phandle, Int32 addr,Byte pData);

        /*************************************************************
        ˵��������ͬʱ������Ǹ��ᵥ������
        ���룺���Ӿ����handle��enable 0���������棬 1��ͬʱ���棻 Ĭ��Ϊͬʱ����
        �������
        ����ֵ��������
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCConfigLatchMode")]
        public static extern  Int32 SMCConfigLatchMode(IntPtr phandle, Byte enable);


        /*************************************************************
        ˵�������ñ�����LTC��Ч��ƽ
        ���룺���Ӿ����handle��enable 0���͵�ƽ�� 1���ߵ�ƽ�� Ĭ��Ϊ�͵�ƽ
        �������
        ����ֵ��������
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCSetLatchValidConfig")]
        public static extern  Int32 SMCSetLatchValidConfig(IntPtr phandle,Byte axis, Byte enable);

        /*************************************************************
        ˵������ȡ������LTC��Ч��ƽ
        ���룺���Ӿ����handle��
        �����enable 0���͵�ƽ�� 1���ߵ�ƽ�� Ĭ��Ϊ�͵�ƽ
        ����ֵ��������
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCGetLatchValidConfig")]
        public static extern  Int32 SMCGetLatchValidConfig(IntPtr phandle,  Byte axis, ref Byte enable);

        /*************************************************************
        ˵������ȡ����ͬʱ������Ǹ��ᵥ������
        ���룺���Ӿ����handle��enable 0���������棬 1��ͬʱ���棻 Ĭ��Ϊͬʱ����
        �������
        ����ֵ��������
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCGetConfigLatchMode")]
        public static extern  Int32 SMCGetConfigLatchMode(IntPtr phandle, ref Byte enable);

        /*************************************************************
        ˵����ѡ��ȫ������ʱ���ⴥ���ź�ͨ���������ɶ����ź�ͨ�����룬
                     ��LTC0, LTC1; Ĭ��ΪLTC0
        ���룺���Ӿ����handle��num �ź�ͨ��ѡ��� 0: LTC0�����ĸ��ᣬ         1: LTC1�����ĸ���
        �������
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCTrigerChunnel")]
        public static extern  Int32 SMCTrigerChunnel(IntPtr phandle, Byte num);

        /*************************************************************
        ˵����ѡ�������Speaker��LED������߼�, Ĭ��Ϊ����Ч
        ���룺���Ӿ����handle��logic 0: ����Ч��       1: ����Ч
        �������
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetSpeakerLogic")]
        public static extern  Int32 SMCSetSpeakerLogic(IntPtr phandle, Byte logic);

        /*************************************************************
        ˵����ѡ�������Speaker��LED������߼�, Ĭ��Ϊ����Ч
        ���룺���Ӿ����handle��logic 0: ����Ч��       1: ����Ч
        �������
        ����ֵ��������
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCGetSpeakerLogic")]
        public static extern  Int32 SMCGetSpeakerLogic(IntPtr phandle, ref Byte logic);

        /*************************************************************
        ˵���� ����EZ���߼���EZ������ʽ;
        ���룺axis 
	           ez_logic�� 0������Ч�� 1������Ч
               ez_mode: �ݿ���0��1
				           0��EZ�ź���Ч
                           1: ����1��EZ�Ǽ�������λ�ź� 
                           2: ����2��EZ��ԭ���źţ��Ҳ���λ������ 
                           3: ����3��EZ��ԭ���źţ��Ҹ�λ������
        �������
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCConfigEZPIN")]
        public static extern  Int32 SMCConfigEZPIN(IntPtr phandle,Byte axis,Byte ez_logic, Byte ez_mode);

        /*************************************************************
        ���ܣ����ñ���������ڵļ�����ʽ��
        ������  axis�����
		        mode����������������ģʽ
			        0 ��A/B ��, Ϊ����+����
			        1 1 �� A/B �������ź�
			        2 2 ��A/B �������ź�
			        3 4 ��A/B �������ź�
        ����ֵ����
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCConfigCounter")]
        public static extern  Int32 SMCConfigCounter(IntPtr phandle,Byte axis,Byte mode);

        /*************************************************************
        ���ܣ����ñ���������ڵļ�����ʽ��
        ������  axis�����
        �����	mode����������������ģʽ
			        0 ��A/B ��, Ϊ����+����
			        1 1 �� A/B �������ź�
			        2 2 ��A/B �������ź�
			        3 4 ��A/B �������ź�
        ����ֵ����
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetCounterConfig")]
        public static extern  Int32 SMCGetCounterConfig(IntPtr phandle,Byte axis,ref Byte mode);

        /*************************************************************
        ˵����  ��ȡEZ�������߼���EZ������ʽ;
        ���룺axis 
	           ez_logic�� 0������Ч�� 1������Ч
               ez_mode: �ݿ���0��1
				           0��EZ�ź���Ч
                           1: ����1��EZ�Ǽ�������λ�ź� 
                           2: ����2��EZ��ԭ���źţ��Ҳ���λ������ 
                           3: ����3��EZ��ԭ���źţ��Ҹ�λ������
        �������
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetConfigEZPIN")]
        public static extern  Int32 SMCGetConfigEZPIN(IntPtr phandle,Byte axis,ref Byte ez_logic, ref Byte ez_mode);

        /*************************************************************
        ˵�������㣬����ģʽͨ������ָ��
        ���룺������handle ��ţ� ����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCIndexHome")]
        public static extern  Int32 SMCIndexHome(IntPtr phandle,Byte iaxis,Byte EzTimes);

        /*************************************************************
        ˵�������㣬����ģʽͨ������ָ��
        ���룺������handle ��ţ� ����
        �����
        ����ֵ��������
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCSetEZTimes")]
        public static extern  Int32 SMCSetEZTimes(IntPtr phandle,Byte iaxis,Byte EzTimes);

        /*************************************************************
        ˵�������㣬����ģʽͨ������ָ��
        ���룺������handle ��ţ� ����
        �����
        ����ֵ��������
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCGetEZTimes")]
        public static extern  Int32 SMCGetEZTimes(IntPtr phandle,Byte iaxis,ref Byte EzTimes);

        /*************************************************************
        ˵�������㣬����ģʽͨ������ָ��
        ���룺������handle ��ţ� ����
        �����
        ����ֵ��������
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetHandWheelSet")]
        public static extern  Int32 SMCGetHandWheelSet(IntPtr phandle,Byte iaxis,ref Byte Handset);
    }
}


