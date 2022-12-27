# Synthesizer Project

**TODO**

## Project Management

Project management to keep track of goals and tasks. I find it important to have a direction when doing TDD.

### Tasks

* [x] Github setup
    * [x] Create repo
    * [x] Create setup
    * [x] Create pipeline with tests and dotnet format
* [ ] Synthesizer CRUD
    * [ ] Creating basic synthesizer
    * [ ] Getting synthesizer
    * [ ] Listing synthesizers
    * [ ] Deleting synthesizer
* [ ] Oscillator CRUD
* [ ] Generating audio samples
* [ ] Envelope CRUD
    * [ ] Attaching to synthesizer and saving
    * [ ] Effect on audio sample generation
* [ ] Filter CRUD
    * [ ] Attaching to synthesizer and saving
    * [ ] Effect on audio sample generation

### MVP definition

* Being able to create one synthesizer containing:
    * A sample rate
    * A display name
    * An auto-generated id
    * A master volume control
    * One oscillator containing
        * Waveform
        * Frequency
        * Amplitude
    * One envelope
        * Levels
            * Attack
            * Sustain
        * Timings
            * Attack
            * Decay
            * Release
    * One filter
        * Low
        * High
        * Resonance
* It must be possible to generate audio samples with the synthesizer.
    * The audio samples should be generated in a streamable manner.
* It must be possible to stream the audio to an output audio device in windows.
* Synthesizer configuration should be stored persistently.

### Not decided

* Method of IO - everything is services, could be web-based, GUI, etc.
* Implement the most simple file-based storage, another storage method can be found later.
* Deployment style of application.

### Future stuff

* Polyphonic audio generation
* MIDI input
* Web-based input
* GUI
* Other kinds of signal generation
    * From audio files
* Customizable signal paths
    * Recursive signal paths
