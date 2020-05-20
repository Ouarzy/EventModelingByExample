[<AutoOpen>]
module Banking.Tests.Dsl

open Swensen.Unquote

let Given = id

let When eventProducer events =
    eventProducer events

let Then (expectedEvents: seq<'T>) (actualEvents: seq<'T>) =
    test <@ expectedEvents = actualEvents @>
