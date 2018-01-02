﻿namespace ClashRoyale.Logic.Scoring.Entries
{
    using ClashRoyale.Extensions;
    using ClashRoyale.Extensions.Helper;
    using ClashRoyale.Files.Csv.Logic;
    using ClashRoyale.Logic.Alliance;

    public class AllianceRankingEntry : RankingEntry
    {
        private AllianceBadgeData AllianceBadgeData;
        private RegionData AllianceRegionData;

        private int NumberOfMembers;

        /// <summary>
        /// Initializes a new instance of the <see cref="AllianceRankingEntry"/> class.
        /// </summary>
        /// <param name="Clan">The alliance.</param>
        public AllianceRankingEntry(Clan Clan)
        {
            this.Initialize(Clan);
        }

        /// <summary>
        /// Initializes the specified alliance.
        /// </summary>
        /// <param name="Clan">The alliance.</param>
        public void Initialize(Clan Clan)
        {
            base.Initialize(Clan.AllianceId, Clan.HeaderEntry.Name, Clan.HeaderEntry.Score, 1, 1);

            this.AllianceRegionData    = Clan.HeaderEntry.Region;
            this.AllianceBadgeData     = Clan.HeaderEntry.Badge;
            this.NumberOfMembers       = Clan.HeaderEntry.NumberOfMembers;
        }

        /// <summary>
        /// Determines whether the specified scored clan is better.
        /// </summary>
        /// <param name="ScoredClan">The scored clan.</param>
        /// <returns>
        ///   <c>true</c> if the specified scored clan is better; otherwise, <c>false</c>.
        /// </returns>
        public bool IsBetter(AllianceRankingEntry ScoredClan)
        {
            return this.Score > ScoredClan.Score;
        }

        /// <summary>
        /// Encodes in the specified stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public void Encode(ByteStream Stream)
        {
            base.Encode(Stream);

            Stream.EncodeData(this.AllianceBadgeData);
            Stream.EncodeData(this.AllianceRegionData);

            Stream.WriteVInt(this.NumberOfMembers);
        }
    }
}