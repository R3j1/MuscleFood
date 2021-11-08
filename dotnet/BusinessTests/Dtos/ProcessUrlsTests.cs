using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using SDK.Models.Dtos;
using Business.Dtos;
using Business.Dtos.Coding;

namespace Business.Tests
{
    [TestClass()]
    public class ProcessUrlsTests
    {
        [TestMethod()]
        public void EncodeUrlsTestNotNullOrEmpty()
        {
            try
            {
                List<OriginalUrlDto> urlsToEncode = new List<OriginalUrlDto>()
                {
                    new OriginalUrlDto { OriginalUrl = "https://www.musclefood.com/" },
                    new OriginalUrlDto { OriginalUrl = "https://coinmarketcap.com/" },
                    new OriginalUrlDto { OriginalUrl = "https://www.wikipedia.org/" },
                    new OriginalUrlDto { OriginalUrl = "https://www.nicehash.com/my/mining/stats" }

                };

                ProcessUrls processor = new ProcessUrls(new CryptoService());
                List<ShortenedUrlDto> encodedUrls = new List<ShortenedUrlDto>();
                foreach (var url in urlsToEncode)
                {
                    string encodedUrl = processor.EncodProcessor(url.OriginalUrl);
                    encodedUrls.Add(new ShortenedUrlDto { ShortenedUrl = encodedUrl });
                    Assert.IsTrue(!string.IsNullOrEmpty(encodedUrl), "EncodeUrlsTest is null or empty");
                }
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Exception");
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void TestEncodedTagPresentTest()
        {
            try
            {
                OriginalUrlDto originalUrl = new OriginalUrlDto
                {
                    OriginalUrl = "https://www.youtube.com/watch?v=Yw6u6YkTgQ4"
                };

                ProcessUrls processor = new ProcessUrls(new CryptoService());

                ShortenedUrlDto encodedUrl = new ShortenedUrlDto
                {
                    ShortenedUrl = processor.EncodProcessor(originalUrl.OriginalUrl)
                };

                Assert.IsTrue(new FormatUrl().IsEncryptedUrl(encodedUrl.ShortenedUrl), "Failed to Add Encryption Tag in TestEncodedTagPresentTest");
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Exception");
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void EncodeAndDecodeProcessTest()
        {
            try
            {
                OriginalUrlDto originalUrl = new OriginalUrlDto
                {
                    OriginalUrl = "https://www.youtube.com/watch?v=Yw6u6YkTgQ4"
                };

                ProcessUrls processor = new ProcessUrls(new CryptoService());

                ShortenedUrlDto encodedUrl = new ShortenedUrlDto
                {
                    ShortenedUrl = processor.EncodProcessor(originalUrl.OriginalUrl)
                };

                Assert.AreEqual(originalUrl.OriginalUrl, processor.DecodeProcessor(encodedUrl.ShortenedUrl));
            }
            catch(Exception ex)
            {
                StringAssert.Contains(ex.Message, "Exception");
                Assert.Fail();
            }
        }
    }
}