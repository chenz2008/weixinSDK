﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Deepleo.Weixin.SDK.Helpers;
using Deepleo.Web.Models;
using Deepleo.Weixin.SDK.JSSDK;
using System.Text.RegularExpressions;
using Deepleo.Web.Attribute;

namespace Deepleo.Web.Controllers
{
    public class JSSDKController : Controller
    {
        public ActionResult Index()
        {
            var appId = WeixinConfig.AppID;
            var nonceStr = Util.CreateNonce_str();
            var timestamp = Util.CreateTimestamp();
            var domain = System.Configuration.ConfigurationManager.AppSettings["Domain"];
            var url = domain + Request.Url.PathAndQuery;
            var jsTickect = WeixinConfig.TokenHelper.GetJSTickect();
            var string1 = "";
            var signature = JSAPI.GetSignature(jsTickect, nonceStr, timestamp, url, out string1);
            var model = new JSSDKModel
            {
                appId = appId,
                nonceStr = nonceStr,
                signature = signature,
                timestamp = timestamp,
                shareUrl = url,
                jsapiTicket = jsTickect,
                shareImg = domain + Url.Content("/images/ad.jpg"),
                string1 = string1,
            };
            return View(model);
        }

    }
}
