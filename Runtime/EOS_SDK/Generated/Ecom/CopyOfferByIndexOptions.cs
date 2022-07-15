// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Ecom
{
	/// <summary>
	/// Input parameters for the <see cref="EcomInterface.CopyOfferByIndex" /> function.
	/// </summary>
	public struct CopyOfferByIndexOptions
	{
		/// <summary>
		/// The Epic Account ID of the local user whose offer is being copied
		/// </summary>
		public EpicAccountId LocalUserId { get; set; }

		/// <summary>
		/// The index of the offer to get.
		/// </summary>
		public uint OfferIndex { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct CopyOfferByIndexOptionsInternal : ISettable<CopyOfferByIndexOptions>, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_LocalUserId;
		private uint m_OfferIndex;

		public EpicAccountId LocalUserId
		{
			set
			{
				Helper.Set(value, ref m_LocalUserId);
			}
		}

		public uint OfferIndex
		{
			set
			{
				m_OfferIndex = value;
			}
		}

		public void Set(ref CopyOfferByIndexOptions other)
		{
			m_ApiVersion = EcomInterface.CopyofferbyindexApiLatest;
			LocalUserId = other.LocalUserId;
			OfferIndex = other.OfferIndex;
		}

		public void Set(ref CopyOfferByIndexOptions? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = EcomInterface.CopyofferbyindexApiLatest;
				LocalUserId = other.Value.LocalUserId;
				OfferIndex = other.Value.OfferIndex;
			}
		}

		public void Dispose()
		{
			Helper.Dispose(ref m_LocalUserId);
		}
	}
}