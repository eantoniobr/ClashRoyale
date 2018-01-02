﻿namespace ClashRoyale.Logic.Shop.Items
{
    using ClashRoyale.Extensions;
    using ClashRoyale.Extensions.Helper;
    using ClashRoyale.Files.Csv.Logic;

    using Newtonsoft.Json.Linq;

    public class ResourceShopItem : ShopItem
    {
        public bool Free;
        public int Amount;

        /// <summary>
        /// Gets the spell shop item type of this instance.
        /// </summary>
        public override int Type
        {
            get
            {
                return 2;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceShopItem"/> class.
        /// </summary>
        public ResourceShopItem() : base()
        {
            // ResourceShopItem.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceShopItem"/> class.
        /// </summary>
        public ResourceShopItem(int ShopIndex, int Cost, ResourceData BuyResourceData, int Amount, bool Free) : base(ShopIndex, Cost, BuyResourceData)
        {
            this.Free = Free;
            this.Amount = Amount;
        }

        /// <summary>
        /// Decodes this instance.
        /// </summary>
        public override void Decode(ByteStream Stream)
        {
            base.Decode(Stream);

            this.Amount = Stream.ReadVInt();
            this.Free = Stream.ReadBoolean();
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        public override void Encode(ByteStream Stream)
        {
            base.Encode(Stream);

            Stream.WriteVInt(this.Amount);
            Stream.WriteBoolean(this.Free);
        }

        /// <summary>
        /// Loads this instance from json.
        /// </summary>
        public override void Load(JToken Json)
        {
            base.Load(Json);

            JsonHelper.GetJsonNumber(Json, "amount", out this.Amount);
            JsonHelper.GetJsonBoolean(Json, "free", out this.Free);
        }

        /// <summary>
        /// Saves this instance to json.
        /// </summary>
        public override JObject Save()
        {
            JObject Json = base.Save();

            Json.Add("amount", this.Amount);
            Json.Add("free", this.Free);

            return Json;
        }
    }
}