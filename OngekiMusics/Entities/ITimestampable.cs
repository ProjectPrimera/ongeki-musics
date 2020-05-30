using System;

namespace OngekiMusics.Entities {
    public interface ITimestampable {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
