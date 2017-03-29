﻿// <copyright file="LittleEndianBitConverter.CopyBytesTests.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Tests.IO
{
    using System;
    using ImageSharp.IO;
    using Xunit;

    /// <summary>
    /// The <see cref="LittleEndianBitConverter"/> tests.
    /// </summary>
    public class LittleEndianBitConverterCopyBytesTests
    {
        [Fact]
        public void CopyToWithNullBufferThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes(false, null, 0));
            Assert.Throws<ArgumentNullException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes((short)42, null, 0));
            Assert.Throws<ArgumentNullException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes((ushort)42, null, 0));
            Assert.Throws<ArgumentNullException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes(42, null, 0));
            Assert.Throws<ArgumentNullException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes(42u, null, 0));
            Assert.Throws<ArgumentNullException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes(42L, null, 0));
            Assert.Throws<ArgumentNullException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes((ulong)42L, null, 0));
        }

        [Fact]
        public void CopyToWithIndexTooBigThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes(false, new byte[1], 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes((short)42, new byte[2], 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes((ushort)42, new byte[2], 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes(42, new byte[4], 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes(42u, new byte[4], 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes(42L, new byte[8], 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes((ulong)42L, new byte[8], 1));
        }

        [Fact]
        public void CopyToWithBufferTooSmallThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes(false, new byte[0], 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes((short)42, new byte[1], 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes((ushort)42, new byte[1], 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes(42, new byte[3], 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes(42u, new byte[3], 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes(42L, new byte[7], 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => EndianBitConverter.LittleEndianConverter.CopyBytes((ulong)42L, new byte[7], 0));
        }

        /// <summary>
        /// Tests that passing a <see cref="bool"/> returns the correct bytes.
        /// </summary>
        [Fact]
        public void CopyBytesBoolean()
        {
            byte[] buffer = new byte[1];

            EndianBitConverter.LittleEndianConverter.CopyBytes(false, buffer, 0);
            this.CheckBytes(new byte[] { 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(true, buffer, 0);
            this.CheckBytes(new byte[] { 1 }, buffer);
        }

        /// <summary>
        /// Tests that passing a <see cref="short"/> returns the correct bytes.
        /// </summary>
        [Fact]
        public void CopyBytesShort()
        {
            byte[] buffer = new byte[2];

            EndianBitConverter.LittleEndianConverter.CopyBytes((short)0, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes((short)1, buffer, 0);
            this.CheckBytes(new byte[] { 1, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes((short)256, buffer, 0);
            this.CheckBytes(new byte[] { 0, 1 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes((short)-1, buffer, 0);
            this.CheckBytes(new byte[] { 255, 255 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes((short)257, buffer, 0);
            this.CheckBytes(new byte[] { 1, 1 }, buffer);
        }

        /// <summary>
        /// Tests that passing a <see cref="ushort"/> returns the correct bytes.
        /// </summary>
        [Fact]
        public void CopyBytesUShort()
        {
            byte[] buffer = new byte[2];

            EndianBitConverter.LittleEndianConverter.CopyBytes((ushort)0, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes((ushort)1, buffer, 0);
            this.CheckBytes(new byte[] { 1, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes((ushort)256, buffer, 0);
            this.CheckBytes(new byte[] { 0, 1 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(ushort.MaxValue, buffer, 0);
            this.CheckBytes(new byte[] { 255, 255 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes((ushort)257, buffer, 0);
            this.CheckBytes(new byte[] { 1, 1 }, buffer);
        }

        /// <summary>
        /// Tests that passing a <see cref="int"/> returns the correct bytes.
        /// </summary>
        [Fact]
        public void CopyBytesInt()
        {
            byte[] buffer = new byte[4];

            EndianBitConverter.LittleEndianConverter.CopyBytes(0, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(1, buffer, 0);
            this.CheckBytes(new byte[] { 1, 0, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(256, buffer, 0);
            this.CheckBytes(new byte[] { 0, 1, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(65536, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 1, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(16777216, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 0, 1 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(-1, buffer, 0);
            this.CheckBytes(new byte[] { 255, 255, 255, 255 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(257, buffer, 0);
            this.CheckBytes(new byte[] { 1, 1, 0, 0 }, buffer);
        }

        /// <summary>
        /// Tests that passing a <see cref="uint"/> returns the correct bytes.
        /// </summary>
        [Fact]
        public void CopyBytesUInt()
        {
            byte[] buffer = new byte[4];

            EndianBitConverter.LittleEndianConverter.CopyBytes((uint)0, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes((uint)1, buffer, 0);
            this.CheckBytes(new byte[] { 1, 0, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes((uint)256, buffer, 0);
            this.CheckBytes(new byte[] { 0, 1, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes((uint)65536, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 1, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes((uint)16777216, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 0, 1 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(uint.MaxValue, buffer, 0);
            this.CheckBytes(new byte[] { 255, 255, 255, 255 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes((uint)257, buffer, 0);
            this.CheckBytes(new byte[] { 1, 1, 0, 0 }, buffer);
        }

        /// <summary>
        /// Tests that passing a <see cref="long"/> returns the correct bytes.
        /// </summary>
        [Fact]
        public void CopyBytesLong()
        {
            byte[] buffer = new byte[8];

            EndianBitConverter.LittleEndianConverter.CopyBytes(0L, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(1L, buffer, 0);
            this.CheckBytes(new byte[] { 1, 0, 0, 0, 0, 0, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(256L, buffer, 0);
            this.CheckBytes(new byte[] { 0, 1, 0, 0, 0, 0, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(65536L, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 1, 0, 0, 0, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(16777216L, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 0, 1, 0, 0, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(4294967296L, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 0, 0, 1, 0, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(1099511627776L, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 0, 0, 0, 1, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(1099511627776L * 256, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 0, 0, 0, 0, 1, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(1099511627776L * 256 * 256, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(-1L, buffer, 0);
            this.CheckBytes(new byte[] { 255, 255, 255, 255, 255, 255, 255, 255 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(257L, buffer, 0);
            this.CheckBytes(new byte[] { 1, 1, 0, 0, 0, 0, 0, 0 }, buffer);
        }

        /// <summary>
        /// Tests that passing a <see cref="ulong"/> returns the correct bytes.
        /// </summary>
        [Fact]
        public void CopyBytesULong()
        {
            byte[] buffer = new byte[8];

            EndianBitConverter.LittleEndianConverter.CopyBytes(0UL, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(1UL, buffer, 0);
            this.CheckBytes(new byte[] { 1, 0, 0, 0, 0, 0, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(256UL, buffer, 0);
            this.CheckBytes(new byte[] { 0, 1, 0, 0, 0, 0, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(65536UL, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 1, 0, 0, 0, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(16777216UL, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 0, 1, 0, 0, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(4294967296UL, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 0, 0, 1, 0, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(1099511627776UL, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 0, 0, 0, 1, 0, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(1099511627776UL * 256, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 0, 0, 0, 0, 1, 0 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(1099511627776UL * 256 * 256, buffer, 0);
            this.CheckBytes(new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(ulong.MaxValue, buffer, 0);
            this.CheckBytes(new byte[] { 255, 255, 255, 255, 255, 255, 255, 255 }, buffer);
            EndianBitConverter.LittleEndianConverter.CopyBytes(257UL, buffer, 0);
            this.CheckBytes(new byte[] { 1, 1, 0, 0, 0, 0, 0, 0 }, buffer);
        }

        /// <summary>
        /// Tests the two byte arrays for equality.
        /// </summary>
        /// <param name="expected">The expected bytes.</param>
        /// <param name="actual">The actual bytes.</param>
        private void CheckBytes(byte[] expected, byte[] actual)
        {
            Assert.Equal(expected.Length, actual.Length);
            Assert.Equal(expected, actual);
        }
    }
}