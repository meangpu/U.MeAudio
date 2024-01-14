//
// Copyright (c) 2023 Warped Imagination. All rights reserved.
//

using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using Meangpu.Audio;

namespace WarpedImagination.AudioPreviewTool
{
    /// <summary>
    /// Audio Preview Tool plays audio in the project view when an Audio Clip is double clicked
    /// </summary>
    public static class AudioPreviewTool
    {
        static int? _lastPlayedAudioClipId = null;
        /// <summary>
        /// Runs when someone double clicks on an audio file in the project window
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        [OnOpenAsset]
        public static bool OnOpenAssetCallback(int instanceId)
        {
            // check that the tool is enabled under preferences
            if (!AudioPreviewToolSettings.Enabled)
                return false;

            UnityEngine.Object obj = EditorUtility.InstanceIDToObject(instanceId);

            if (obj is AudioClip audioClip)
            {
                OpenNormalAudioClip(instanceId, audioClip);
                return true;
            }

            if (obj is SOSound meSoSOund)
            {
                OpenSOSound(instanceId, meSoSOund);
                return true;
            }

            return false;
        }

        private static void OpenSOSound(int instanceId, SOSound meSoSOund)
        {
            if (IsPreviewClipPlaying())
            {
                StopAllPreviewClips();

                if (_lastPlayedAudioClipId.HasValue &&
                    _lastPlayedAudioClipId.Value != instanceId)
                {
                    PlayPreviewClip(meSoSOund.Clip);
                }
            }
            else
            {
                PlayPreviewClip(meSoSOund.Clip);
            }

            _lastPlayedAudioClipId = instanceId;
        }

        private static void OpenNormalAudioClip(int instanceId, AudioClip audioClip)
        {
            if (IsPreviewClipPlaying())
            {
                StopAllPreviewClips();

                if (_lastPlayedAudioClipId.HasValue &&
                    _lastPlayedAudioClipId.Value != instanceId)
                {
                    PlayPreviewClip(audioClip);
                }
            }
            else
            {
                PlayPreviewClip(audioClip);
            }

            _lastPlayedAudioClipId = instanceId;
        }

        public static void PlayPreviewClip(AudioClip audioClip)
        {
            Assembly unityAssembly = typeof(AudioImporter).Assembly;
            Type audioUtil = unityAssembly.GetType("UnityEditor.AudioUtil");
            MethodInfo methodInfo = audioUtil.GetMethod(
                "PlayPreviewClip",
                BindingFlags.Static | BindingFlags.Public,
                null,
                new System.Type[] { typeof(AudioClip), typeof(Int32), typeof(Boolean) },
                null);

            methodInfo.Invoke(null, new object[] { audioClip, 0, false });
        }

        public static bool IsPreviewClipPlaying()
        {
            Assembly unityAssembly = typeof(AudioImporter).Assembly;
            Type audioUtil = unityAssembly.GetType("UnityEditor.AudioUtil");
            MethodInfo methodInfo = audioUtil.GetMethod(
                "IsPreviewClipPlaying",
                BindingFlags.Static | BindingFlags.Public);

            bool isPlaying = (bool)methodInfo.Invoke(null, null);

            return isPlaying;
        }

        public static void StopAllPreviewClips()
        {
            Assembly unityAssembly = typeof(AudioImporter).Assembly;
            Type audioUtil = unityAssembly.GetType("UnityEditor.AudioUtil");
            MethodInfo methodInfo = audioUtil.GetMethod(
                "StopAllPreviewClips",
                BindingFlags.Static | BindingFlags.Public);

            methodInfo.Invoke(null, null);
        }
    }
}