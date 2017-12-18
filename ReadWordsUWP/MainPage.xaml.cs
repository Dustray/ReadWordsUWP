using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace ReadWordsUWP
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void readMeBtn_Click(object sender, RoutedEventArgs e)
        {
            
            speech();
        }
        private async void speech()
        {
            string str= "孙学刚，起床了。";
            if (readMeText.Text!="")
                str= readMeText.Text;
            string Ssml =
                @"<speak version='1.0' " +
                "xmlns='http://www.w3.org/2001/10/synthesis' xml:lang='zh-CN'>" +
                "<voice gender ='male'>"+
                "<prosody rate = '-30%' contour='(60%,+800Hz) (70%,+80%) (80%,+800Hz)'>"+
                str +
                "</prosody> " +
                "<break time='0ms'/>" +
                "</voice>" +
                "</speak>";
            
            MediaElement mediaElement = this.mediaelement;

            // The object for controlling the speech synthesis engine (voice).
            var synth = new SpeechSynthesizer();

            // Generate the audio stream from plain text.
            SpeechSynthesisStream stream = await synth.SynthesizeSsmlToStreamAsync(Ssml);

            // Send the stream to the media object.
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();

        }
    }
}
