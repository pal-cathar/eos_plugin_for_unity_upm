/*
* Copyright (c) 2021 PlayEveryWare
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*/
#if !EOS_DISABLE
using Epic.OnlineServices.Platform;
#endif
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayEveryWare.EpicOnlineServices
{

    /// <summary>
    /// Represents the EOS Configuration used for initializing EOS SDK.
    /// </summary>
    [Serializable]
    public class EOSConfig : ICloneableGeneric<EOSConfig>, IEmpty
    {
        /// <value><c>Product Name</c> defined in the [Development Portal](https://dev.epicgames.com/portal/)</value>
        public string productName;

        /// <value>Version of Product</value>
        public string productVersion;

        /// <value><c>Product Id</c> defined in the [Development Portal](https://dev.epicgames.com/portal/)</value>
        public string productID;

        /// <value><c>Sandbox Id</c> defined in the [Development Portal](https://dev.epicgames.com/portal/)</value>
        public string sandboxID;

        /// <value><c>Deployment Id</c> defined in the [Development Portal](https://dev.epicgames.com/portal/)</value>
        public string deploymentID;

        /// <value><c>Client Secret</c> defined in the [Development Portal](https://dev.epicgames.com/portal/)</value>
        public string clientSecret;

        /// <value><c>Client Id</c> defined in the [Development Portal](https://dev.epicgames.com/portal/)</value>
        public string clientID;

        /// <value><c>Encryption Key</c> used by default to decode files previously encoded and stored in EOS</value>
        public string encryptionKey;

        /// <value><c>Flags</c> used to initilize the EOS platform.</value>
        public List<string> platformOptionsFlags;

        public uint tickBudgetInMilliseconds;

        public string ThreadAffinity_networkWork;
        public string ThreadAffinity_storageIO;
        public string ThreadAffinity_webSocketIO;
        public string ThreadAffinity_P2PIO;
        public string ThreadAffinity_HTTPRequestIO;
        public string ThreadAffinity_RTCIO;


        /// <value><c>Always Send Input to Overlay </c>If true, the plugin will always send input to the overlay from the C# side to native, and handle showing the overlay. This doesn't always mean input makes it to the EOS SDK</value>
        public bool alwaysSendInputToOverlay;

        /// <value><c>Initial Button Delay</c> Stored as a string so it can be 'empty'</value>
        public string initialButtonDelayForOverlay;

        /// <value><c>Rpeat button delay for overlay</c> Stored as a string so it can be 'empty' </value>
        public string repeatButtonDelayForOverlay;

        /// <value><c>HACK: send force send input without delay</c>If true, the native plugin will always send input received directly to the SDK. If set to false, the plugin will attempt to delay the input to mitigate CPU spikes caused by spamming the SDK </value>
        public bool hackForceSendInputDirectlyToSDK;


        //-------------------------------------------------------------------------
        //TODO: Move this to a shared place
        public static bool StringIsEqualToAny(string flagAsCString, params string[] parameters)
        {
            foreach(string s in parameters)
            {
                if (flagAsCString == s)
                {
                    return true;
                }
            }
            return false;
        }

        public static T EnumCast<T, V>(V value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }
#if !EOS_DISABLE
        //-------------------------------------------------------------------------
        public static Epic.OnlineServices.IntegratedPlatform.IntegratedPlatformManagementFlags flagsAsIntegratedPlatformManagementFlags(List<string> flags)
        {
            int toReturn = 0;
 
            foreach (var flagAsCString in flags)
            {
                if (StringIsEqualToAny(flagAsCString, "EOS_IPMF_Disabled", "Disabled"))
                {
                    toReturn |= (int)Epic.OnlineServices.IntegratedPlatform.IntegratedPlatformManagementFlags.Disabled;
                }
                else if (StringIsEqualToAny(flagAsCString, "EOS_IPMF_ManagedByApplication", "ManagedByApplication", "EOS_IPMF_LibraryManagedByApplication"))
                {
                    toReturn |= (int)Epic.OnlineServices.IntegratedPlatform.IntegratedPlatformManagementFlags.LibraryManagedByApplication;
                }
                else if (StringIsEqualToAny(flagAsCString,"EOS_IPMF_ManagedBySDK", "ManagedBySDK", "EOS_IPMF_LibraryManagedBySDK"))
                {
                    toReturn |= (int)Epic.OnlineServices.IntegratedPlatform.IntegratedPlatformManagementFlags.LibraryManagedBySDK;
                }
                else if (StringIsEqualToAny(flagAsCString, "EOS_IPMF_DisableSharedPresence", "DisableSharedPresence", "EOS_IPMF_DisablePresenceMirroring"))
                {
                    toReturn |= (int)Epic.OnlineServices.IntegratedPlatform.IntegratedPlatformManagementFlags.DisablePresenceMirroring;
                }
                else if (StringIsEqualToAny(flagAsCString, "EOS_IPMF_DisableSessions", "DisableSessions", "EOS_IPMF_DisableSDKManagedSessions"))
                {
                    toReturn |= (int)Epic.OnlineServices.IntegratedPlatform.IntegratedPlatformManagementFlags.DisableSDKManagedSessions;
                }
                else if (StringIsEqualToAny(flagAsCString, "EOS_IPMF_PreferEOS", "PreferEOS", "EOS_IPMF_PreferEOSIdentity"))
                {
                    toReturn |= (int)Epic.OnlineServices.IntegratedPlatform.IntegratedPlatformManagementFlags.PreferEOSIdentity;
                }
                else if (StringIsEqualToAny(flagAsCString, "EOS_IPMF_PreferIntegrated", "PreferIntegrated", "EOS_IPMF_PreferIntegratedIdentity"))
                {
                    toReturn |= (int)Epic.OnlineServices.IntegratedPlatform.IntegratedPlatformManagementFlags.PreferIntegratedIdentity;
                }
            }

            return EnumCast<Epic.OnlineServices.IntegratedPlatform.IntegratedPlatformManagementFlags, int>(toReturn);
        }

        //-------------------------------------------------------------------------
        public static PlatformFlags platformOptionsFlagsAsPlatformFlags(List<string> platformOptionsFlags)
        {
            PlatformFlags toReturn = PlatformFlags.None;

            foreach(var flagAsString in platformOptionsFlags)
            {
                if(flagAsString == "LoadingInEditor" || flagAsString == "EOS_PF_LOADING_IN_EDITOR")
                {
                    toReturn |= PlatformFlags.LoadingInEditor;
                }

                else if(flagAsString == "DisableOverlay" || flagAsString == "EOS_PF_DISABLE_OVERLAY")
                {
                    toReturn |= PlatformFlags.DisableOverlay;
                }

                else if(flagAsString == "DisableSocialOverlay" || flagAsString == "EOS_PF_DISABLE_SOCIAL_OVERLAY")
                {
                    toReturn |= PlatformFlags.DisableSocialOverlay;
                }

                else if(flagAsString == "Reserved1" || flagAsString == "EOS_PF_RESERVED1")
                {
                    toReturn |= PlatformFlags.Reserved1;
                }

                else if(flagAsString == "WindowsEnabledOverlayD3D9" || flagAsString == "EOS_PF_WINDOWS_ENABLE_OVERLAY_D3D9")
                {
                    toReturn |= PlatformFlags.WindowsEnableOverlayD3D9;
                }
                else if(flagAsString == "WindowsEnabledOverlayD3D10" || flagAsString == "EOS_PF_WINDOWS_ENABLE_OVERLAY_D3D10")
                {
                    toReturn |= PlatformFlags.WindowsEnableOverlayD3D10;
                }
                else if(flagAsString == "WindowsEnabledOverlayOpengl" || flagAsString == "EOS_PF_WINDOWS_ENABLE_OVERLAY_OPENGL")
                {
                    toReturn |= PlatformFlags.WindowsEnableOverlayOpengl;
                }
            }

            return toReturn;
        }
#endif
        //-------------------------------------------------------------------------
        /// <summary>
        /// Creates a shallow copy of the current <c>EOSConfig</c>
        /// </summary>
        /// <returns>Shallow copy of <c>EOSConfig</c></returns>
        public EOSConfig Clone()
        {
            return (EOSConfig)this.MemberwiseClone();
        }

        //-------------------------------------------------------------------------
        public bool IsEmpty()
        {
            return EmptyPredicates.IsEmptyOrNull(productName)
                && EmptyPredicates.IsEmptyOrNull(productVersion)
                && EmptyPredicates.IsEmptyOrNull(productID)
                && EmptyPredicates.IsEmptyOrNull(sandboxID)
                && EmptyPredicates.IsEmptyOrNull(deploymentID)
                && EmptyPredicates.IsEmptyOrNull(clientSecret)
                && EmptyPredicates.IsEmptyOrNull(clientID)
                && EmptyPredicates.IsEmptyOrNull(encryptionKey)
                && EmptyPredicates.IsEmptyOrNull(platformOptionsFlags)
                && EmptyPredicates.IsEmptyOrNull(repeatButtonDelayForOverlay)
                && EmptyPredicates.IsEmptyOrNull(initialButtonDelayForOverlay)
                ;
        }


#if !EOS_DISABLE
        //-------------------------------------------------------------------------
        public PlatformFlags platformOptionsFlagsAsPlatformFlags()
        {
            return EOSConfig.platformOptionsFlagsAsPlatformFlags(platformOptionsFlags);
        }

        //-------------------------------------------------------------------------
        public float GetInitialButtonDelayForOverlayAsFloat()
        {
            return float.Parse(initialButtonDelayForOverlay);
        }

        //-------------------------------------------------------------------------
        public void SetInitialButtonDelayForOverlayFromFloat(float f)
        {
            initialButtonDelayForOverlay = f.ToString();
        }

        //-------------------------------------------------------------------------
        public float GetRepeatButtonDelayForOverlayAsFloat()
        {
           return float.Parse(repeatButtonDelayForOverlay);
        }

        //-------------------------------------------------------------------------
        public void SetRepeatButtonDelayForOverlayFromFloat(float f)
        {
            repeatButtonDelayForOverlay = f.ToString();
        }

        //-------------------------------------------------------------------------
        public ulong GetThreadAffinityNetworkWork(ulong defaultValue = 0)
        {
            ulong value;
            if (!string.IsNullOrEmpty(ThreadAffinity_networkWork))
            {
                value = ulong.Parse(ThreadAffinity_networkWork);
            }
            else
            {
                value = defaultValue;
            }

            return value;
        }

        //-------------------------------------------------------------------------
        public ulong GetThreadAffinityStorageIO(ulong defaultValue = 0)
        {
            ulong value;
            if (!string.IsNullOrEmpty(ThreadAffinity_storageIO))
            {
                value = ulong.Parse(ThreadAffinity_storageIO);
            }
            else
            {
                value = defaultValue;
            }
            return value;
        }
 
        //-------------------------------------------------------------------------
        public ulong GetThreadAffinityWebSocketIO(ulong defaultValue = 0)
        {
            ulong value;
            if (!string.IsNullOrEmpty(ThreadAffinity_webSocketIO))
            {
                value = ulong.Parse(ThreadAffinity_webSocketIO);
            }
            else
            {
                value = defaultValue;
            }
            return value;
        }

        //-------------------------------------------------------------------------
        public ulong GetThreadAffinityP2PIO(ulong defaultValue = 0)
        {
            ulong value;
            if (!string.IsNullOrEmpty(ThreadAffinity_P2PIO))
            {
                value = ulong.Parse(ThreadAffinity_P2PIO);
            }
            else
            {
                value = defaultValue;
            }
            return value;
        }

        //-------------------------------------------------------------------------
        public ulong GetThreadAffinityHTTPRequestIO(ulong defaultValue = 0)
        {
            ulong value;
            if (!string.IsNullOrEmpty(ThreadAffinity_HTTPRequestIO))
            {
                value = ulong.Parse(ThreadAffinity_HTTPRequestIO);
            }
            else
            {
                value = defaultValue;
            }
            return value;
        }

        //-------------------------------------------------------------------------
        public ulong GetThreadAffinityRTCIO(ulong defaultValue = 0)
        {
            ulong value;
            if (!string.IsNullOrEmpty(ThreadAffinity_RTCIO))
            {
                value = ulong.Parse(ThreadAffinity_RTCIO);
            }
            else
            {
                value = defaultValue;
            }
            return value;
        }
    }
}
