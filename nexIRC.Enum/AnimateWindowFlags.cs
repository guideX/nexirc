namespace nexIRC.Enum {
    /// <summary>
    /// Animate Window Flags
    /// </summary>
    public enum AnimateWindowFlags : uint {
        /// <summary>
        /// AW_HOR_POSITIVE
        /// </summary>
        AW_HOR_POSITIVE = 0x00000001,
        /// <summary>
        /// AW_HOR_NEGATIVE
        /// </summary>
        AW_HOR_NEGATIVE = 0x00000002,
        /// <summary>
        /// AW_VER_POSITIVE
        /// </summary>
        AW_VER_POSITIVE = 0x00000004,
        /// <summary>
        /// AW_VER_NEGATIVE
        /// </summary>
        AW_VER_NEGATIVE = 0x00000008,
        /// <summary>
        /// AW_VER_NEGATIVE
        /// </summary>
        AW_CENTER = 0x00000010,
        /// <summary>
        /// AW_HIDE
        /// </summary>
        AW_HIDE = 0x00010000,
        /// <summary>
        /// AW_ACTIVATE
        /// </summary>
        AW_ACTIVATE = 0x00020000,
        /// <summary>
        /// AW_SLIDE
        /// </summary>
        AW_SLIDE = 0x00040000,
        /// <summary>
        /// AW_BLEND
        /// </summary>
        AW_BLEND = 0x00080000
    }
}