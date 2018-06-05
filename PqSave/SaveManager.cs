using System;
using System.Linq;
using ZeroFormatter;

namespace PqSave
{
    public class SaveManager
    {
        public CheckData CheckData { get; set; }
        public SerializeData SerializeData { get; set; }

        public SaveManager(byte[] saveEnc)
        {
            var saveDec = Encryption.DecryptSave(saveEnc);
            CheckData = ZeroFormatterSerializer.Deserialize<CheckData>(saveDec);
            SerializeData = ZeroFormatterSerializer.Deserialize<SerializeData>(saveDec, 56);
        }

        public SaveManager() { }

        public byte[] Export()
        {
            var head = ZeroFormatterSerializer.Serialize(CheckData);
            var body = ZeroFormatterSerializer.Serialize(SerializeData);
            var length = head.Length + body.Length;

            var saveDec = new Byte[length];
            Array.Copy(head, saveDec, head.Length);
            Array.Copy(body, 0, saveDec, head.Length, body.Length);

            var saveEnc = Encryption.EncryptSave(saveDec);
            return saveEnc;
        }
    }

    public static class SaveExtensions
    {
        public static void AddGood(this Goods goods, int id)
        {
            if (goods.hasDatas.Any(x => x.id == id)) return;
            goods.hasDatas.Add(new Goods.ManageData { id = id, isNew = true });
        }
    }
}
