// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Leaderboards
{
	/// <summary>
	/// Input parameters for the <see cref="LeaderboardsInterface.QueryLeaderboardUserScores" /> function.
	/// </summary>
	public struct QueryLeaderboardUserScoresOptions
	{
		/// <summary>
		/// An array of Product User IDs indicating the users whose scores you want to retrieve
		/// </summary>
		public ProductUserId[] UserIds { get; set; }

		/// <summary>
		/// The stats to be collected, along with the sorting method to use when determining rank order for each stat
		/// </summary>
		public UserScoresQueryStatInfo[] StatInfo { get; set; }

		/// <summary>
		/// An optional POSIX timestamp, or <see cref="LeaderboardsInterface.TimeUndefined" />; results will only include scores made after this time
		/// </summary>
		public System.DateTimeOffset? StartTime { get; set; }

		/// <summary>
		/// An optional POSIX timestamp, or <see cref="LeaderboardsInterface.TimeUndefined" />; results will only include scores made before this time
		/// </summary>
		public System.DateTimeOffset? EndTime { get; set; }

		/// <summary>
		/// Product User ID for user who is querying user scores.
		/// Must be set when using a client policy that requires a valid logged in user.
		/// Not used for Dedicated Server where no user is available.
		/// </summary>
		public ProductUserId LocalUserId { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct QueryLeaderboardUserScoresOptionsInternal : ISettable<QueryLeaderboardUserScoresOptions>, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_UserIds;
		private uint m_UserIdsCount;
		private System.IntPtr m_StatInfo;
		private uint m_StatInfoCount;
		private long m_StartTime;
		private long m_EndTime;
		private System.IntPtr m_LocalUserId;

		public ProductUserId[] UserIds
		{
			set
			{
				Helper.Set(value, ref m_UserIds, out m_UserIdsCount);
			}
		}

		public UserScoresQueryStatInfo[] StatInfo
		{
			set
			{
				Helper.Set<UserScoresQueryStatInfo, UserScoresQueryStatInfoInternal>(ref value, ref m_StatInfo, out m_StatInfoCount);
			}
		}

		public System.DateTimeOffset? StartTime
		{
			set
			{
				Helper.Set(value, ref m_StartTime);
			}
		}

		public System.DateTimeOffset? EndTime
		{
			set
			{
				Helper.Set(value, ref m_EndTime);
			}
		}

		public ProductUserId LocalUserId
		{
			set
			{
				Helper.Set(value, ref m_LocalUserId);
			}
		}

		public void Set(ref QueryLeaderboardUserScoresOptions other)
		{
			m_ApiVersion = LeaderboardsInterface.QueryleaderboarduserscoresApiLatest;
			UserIds = other.UserIds;
			StatInfo = other.StatInfo;
			StartTime = other.StartTime;
			EndTime = other.EndTime;
			LocalUserId = other.LocalUserId;
		}

		public void Set(ref QueryLeaderboardUserScoresOptions? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = LeaderboardsInterface.QueryleaderboarduserscoresApiLatest;
				UserIds = other.Value.UserIds;
				StatInfo = other.Value.StatInfo;
				StartTime = other.Value.StartTime;
				EndTime = other.Value.EndTime;
				LocalUserId = other.Value.LocalUserId;
			}
		}

		public void Dispose()
		{
			Helper.Dispose(ref m_UserIds);
			Helper.Dispose(ref m_StatInfo);
			Helper.Dispose(ref m_LocalUserId);
		}
	}
}