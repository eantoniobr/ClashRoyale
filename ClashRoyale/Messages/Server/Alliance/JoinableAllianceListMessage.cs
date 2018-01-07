﻿namespace ClashRoyale.Messages.Server.Alliance
{
    using System.Collections.Generic;

    using ClashRoyale.Enums;
    using ClashRoyale.Logic.Alliance.Entries;

    public class JoinableAllianceListMessage : Message
    {
        /// <summary>
        /// Gets the type of this message.
        /// </summary>
        public override short Type
        {
            get
            {
                return 24304;
            }
        }

        /// <summary>
        /// Gets the service node of this message.
        /// </summary>
        public override Node ServiceNode
        {
            get
            {
                return Node.Alliance;
            }
        }

        public List<AllianceHeaderEntry> Alliances;

        /// <summary>
        /// Initializes a new instance of the <see cref="JoinableAllianceListMessage"/> class.
        /// </summary>
        /// <param name="Device">The device.</param>
        /// <param name="Alliances">The alliances.</param>
        public JoinableAllianceListMessage(List<AllianceHeaderEntry> Alliances)
        {
            this.Alliances = Alliances;
        }

        /// <summary>
        /// Encodes this instance;
        /// </summary>
        public override void Encode()
        {
            this.Stream.WriteVInt(this.Alliances.Count);

            this.Alliances.ForEach(Alliance =>
            {
                Alliance.Encode(this.Stream);
            });
        }
    }
}